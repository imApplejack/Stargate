using Stargate.Stargate.Enum;
using Stargate.Stargate.StateMachine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        SELECTCARD,
        CONTINUEQUEST,
        BOOSTCHAR,
        PLAYCOMPLICATION,
        USED
    }

    public abstract class NetworkStargateEvent : Godot.Object
    {
        public int Sender;

        public abstract StargateEvent GenerateStargateEvent();

        public abstract object[] RPCAttr();

        public abstract string RPCMethod();

    }



    public abstract class StargateEvent : StateEvent
    {

        public abstract NetworkStargateEvent GenerateNetworkStargateEvent();

        public EventType Type { get; set; }

        public Player Sender { get; set; }

        public int? SenderId { get; set; } = null;


        public virtual void Hydrate(StargateGame game)
        {

            if (SenderId != null)
            {
                this.Sender = game.GetPlayerById((int)SenderId);
            }
           
        }

        public override string ToString()
        {
            return Type.ToString() + " " + "Sender " + SenderId;
        }

    }
}
