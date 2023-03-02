using Stargate.Stargate.Enum;
using Stargate.Stargate.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.Stargate.Event.Network
{


    public class NetworkStargateEvent
    {

        public EventType Type { get; set; }

        public int Sender { get; set; }


        public static NetworkStargateEvent ConvertFromStargateEvent(NetworkStargateEvent nse,  StargateEvent e, StargateGame game)
        {
            nse.Sender = game.GetPlayerId(e.Sender);
            nse.Type = e.Type;
            return nse;
        }

        public static StargateEvent ConvertToStargateEvent(StargateEvent e, NetworkStargateEvent nse, StargateGame game)
        {
            e.Sender = game.GetPlayerById(nse.Sender);
            e.Type = nse.Type;
            return e;
        }


        public override string ToString()
        {
            return "Type : " + Type + " Sender : " + Sender;
        }

    }
}
