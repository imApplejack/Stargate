using Stargate.Stargate;
using Stargate.Stargate.Enum;
using Stargate.Stargate.Event;
using Stargate.Stargate.StateMachine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.StateMachine
{
    public class StatePhase : StateAction
    {

        public Dictionary<int, StateAction> actions = new Dictionary<int, StateAction>();
        public delegate void Delegate(StateEvent e = null);
        public Dictionary<int, Delegate> delegates = new Dictionary<int, Delegate>();
        public Queue<StateAction> queue = new Queue<StateAction>();


        public int currentOperation = 0;

        public int numElements = 0;

        public StatePhase()
        {
            Init(); 
        }

        public void RestartPhase()
        {
            currentOperation = 0;
            numElements = 0;
            actions = new Dictionary<int, StateAction>();
            delegates = new Dictionary<int, Delegate>();
            queue = new Queue<StateAction>();
        
        }


        public StatePhase AddAction(StateAction myAction)
        {
            myAction.parent = this;
            actions[numElements] = myAction;
            numElements++;
            return this;
        }

        public StatePhase AddAction(Delegate myDelegate)
        {
            delegates[numElements] = myDelegate;
            numElements++;
            return this;
        }

        public StatePhase QueueAction(StateAction myAction)
        {
            myAction.parent = this;
            queue.Enqueue(myAction);
            return this;
        }



        public override void Play(StateEvent e = null)
        {
            int i = currentOperation;
            while (i < numElements || queue.Count > 0)
            {
                try
                {

                    while(queue.Count > 0)
                    {
                        queue.Dequeue().Play(e);
                    }

                    if (actions.ContainsKey(i))
                    {
                        ((StateAction)actions[i]).Play(e);
                    }
                    else if (delegates.ContainsKey(i))
                    {
                        ((Delegate)delegates[i])(e);
                    }

                    
                }
                catch(StateResultException ex) { 
                   
                    if(ex.response == StateResult.STOP)
                    {
                       
                        throw ex;
                        //return;
                    }
                }
                finally {
                    currentOperation = i;
                }

                i++;
            }
           

            
        }

        public override string ToString() { 


            string retour = "///////////\n";
            retour += "moi : " + this.GetType().Name + "\n";

            retour += "mes enfants :" + "\n";

            foreach (var action in actions)
            {
                retour += action.Value.GetType().Name + " ";

            }
            retour += "\n";

            if (parent != null)
            retour += "mon parent :" + parent.GetType().Name + "\n";


           retour += "//////////";




            return retour;

            //return this.GetType().Name;
        }



    }

}
