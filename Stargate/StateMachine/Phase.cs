using Stargate.Stargate;
using Stargate.Stargate.Enum;
using Stargate.Stargate.Event;
using Stargate.Stargate.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.StateMachine
{
    public  class Phase : IPhase
    {
        protected GameState gameState = null;

        public event EventHandler StargateResultHandler;

        public void SendEvent(StargateResult r)
        {
            StargateResultHandler(this, r);
        }

        public Phase(GameState _gameState)
        {
            gameState = _gameState;
            
        }


        public void SendResult(StargateResult result)
        {

        }

        public void ProcessEvent(StargateEvent myEvent)
        {

        }

        public virtual void Init()
        {
            //throw new NotImplementedException();
        }

        public virtual void Run()
        {
            //throw new NotImplementedException();
        }
    }

}
