using Stargate.Stargate.Card;
using Stargate.Stargate.Enum;
using Stargate.Stargate.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.Stargate.Event.Network
{


    public class NetworkSelectCardEvent : NetworkStargateEvent
    {
        public int cardModel { get; set; }

        public static NetworkSelectCardEvent CreateFromStargateEvent(SelectCardEvent e, StargateGame game)
        {
            NetworkSelectCardEvent retour = new NetworkSelectCardEvent();
            retour.cardModel = game.GameState.CardRepository.GetIdFromCardModel(e.cardModel);
            NetworkStargateEvent.ConvertFromStargateEvent(retour, e, game);
            return retour;
        }


        public static SelectCardEvent ConvertToStargateEvent(NetworkSelectCardEvent e, StargateGame game)
        {
            SelectCardEvent retour = new SelectCardEvent();
            retour.cardModel = game.GameState.CardRepository.GetCardModelFromId(e.cardModel);
            NetworkStargateEvent.ConvertToStargateEvent(retour, e , game);
            return retour;
        }


        public override string ToString()
        {
            return base.ToString() + " " + cardModel;

        }


    }
}
