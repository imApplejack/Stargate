using Stargate.Stargate.Enum;
using Stargate.Stargate.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.Stargate.Event
{


    public enum EventType
    {
        PLAYCARD,
        ASSIGNCHAR,
        PASS,
        DRAWCARD,
        SELECTCARD
    }


    public class StargateEvent : StateEvent
    {

        public EventType Type { get; set; }

        public Player Sender { get; set; }


        public override string ToString()
        {
            return Type.ToString() + Sender;
        }


    }
}
