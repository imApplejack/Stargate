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
    public class InitPhase : StatePhase 
    {

        private int toto = 0;
       

        public InitPhase() 
        {
            this.AddAction(new StateAction())
                .AddAction(MyInitDelegateMethod)
                .AddAction(new StateAction())
                .AddAction(MyInitDelegateMethod2);
        }


        public  void MyInitDelegateMethod(StateEvent e = null)
        {
            Debug.WriteLine("MyInitDelegateMethod" +  " toto = " + toto);
            toto++;
        }

        public  void MyInitDelegateMethod2(StateEvent e = null)
        {
            Debug.WriteLine("MyInitDelegateMethod2" + " toto = " + toto);
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
