using Stargate.Stargate;
using Stargate.Stargate.Event;
using Stargate.Stargate.StateMachine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.StateMachine
{
    public class MockPhase : StatePhase 
    {

        private int toto;

        public override void Init()
        {
            toto = 0;
            this
                 .AddAction(new StateAction())
                 .AddAction(MyInitDelegateMethod)
                 .AddAction(MyBlockingAction)
                 .AddAction(new StateAction())
                 .AddAction(MyInitDelegateMethod2)
                ;
        }


        public void MyInitDelegateMethod(StateEvent e = null)
        {
            Debug.WriteLine("MyInitDelegateMethod" +  " toto = " + toto);
            toto++;


            QueueAction(new MockState());

           

        }

        public void MyInitDelegateMethod2(StateEvent e = null)
        {
            Debug.WriteLine("MyInitDelegateMethod2" + " toto = " + toto);

            QueueAction(new MockState()).QueueAction(new MockState());


            


            //RestartPhase();
            //Init();
        }

        public void MyBlockingAction(StateEvent e = null)
        {
            Debug.WriteLine("my blocking action");
            
            if(e == null)
            {
                throw new StateResultException(StateResult.STOP);
            }
            
        }

        /*

       public override void Run()
       {

           SendEvent(gameState.CardService.Draw(gameState.GetHeroPlayer()));
           SendEvent(gameState.CardService.Draw(gameState.GetHeroPlayer()));

           SendEvent(gameState.CardService.Draw(gameState.GetEnemyPlayer()));
           //SendEvent(gameState.CardService.Draw(gameState.GetEnemyPlayer()));





           PopAndNewPhase(new StopPartyCharacter());
       }
       */
    }

}
