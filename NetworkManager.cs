using Stargate.Stargate.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate
{
    public class NetworkManager
    {


        Dictionary<string, NetworkStargateEvent> Eventlist;

        public NetworkManager()
        {
            Eventlist = new Dictionary<string, NetworkStargateEvent>();

            Eventlist.Add(typeof(AssignCharEvent).Name, new NetworkAssignCharEvent());
            Eventlist.Add(typeof(BoostCharEvent).Name, new NetworkBoostCharEvent());
            Eventlist.Add(typeof(ContinueQuestEvent).Name, new NetworkContinueQuestEvent());
            Eventlist.Add(typeof(PassEvent).Name, new NetworkPassEvent());
            Eventlist.Add(typeof(PlayCardEvent).Name, new NetworkPlayCardEvent());
            Eventlist.Add(typeof(PlayComplicationEvent).Name, new NetworkPlayComplicationEvent());
            Eventlist.Add(typeof(SelectCardEvent).Name, new NetworkSelectCardEvent());
        }

       

        public StargateEvent GenerateStargateEvent(string name ,object[] input)
        {
            return Eventlist[name].GenerateStargateEvent(input);
        }



        public object[] GenerateRPCAttr(StargateEvent myEvent){


            //object[] retour = new object[] { myEvent.GetType().Name  };


            //Eventlist[myEvent.GetType().Name].RPCAttr(myEvent);



            // return retour;
            return new object[] { myEvent.GetType().Name , Eventlist[myEvent.GetType().Name].RPCAttr(myEvent) };

          //  return new object[] { myEvent.GetType().Name }.Concat(Eventlist[myEvent.GetType().Name].RPCAttr(myEvent)).ToArray();
        }


    }
}
