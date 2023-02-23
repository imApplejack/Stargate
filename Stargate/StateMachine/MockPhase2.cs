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
    public class MockPhase2 : StatePhase 
    {

        private int toto = 0;
       

        public MockPhase2() 
        {
            this.AddAction(new MockPhase());

        }

        /*
        public void MyInitDelegateMethod(StateEvent e = null)
        {
            Debug.WriteLine("MyInitDelegateMethod" +  " toto = " + toto);
            toto++;
        }

        public void MyInitDelegateMethod2(StateEvent e = null)
        {
            Debug.WriteLine("MyInitDelegateMethod2" + " toto = " + toto);
        }

        public void MyBlockingAction(StateEvent e = null)
        {
            Debug.WriteLine("my blocking action");
            
            if(e == null)
            {
                throw new StateResultException(StateResult.STOP);
            }
            
          
        }
        */

    }

}
