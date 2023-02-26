using Stargate.Stargate.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.Stargate
{

    public class CardModel
    {

       /*
        public static CardModel CreateCardModelFromCard(SGCard card)
        {
            // ici faire un switch & polymorpher eventuellement car tout le monde partage les caracteristiques de tout le monde
            CardModel model = new CardModel() {
                Card = card,
                Combat = card.Combat,
                Cost = card.Cost,
                Culture = card.Culture,
                Ingenuity = card.Ingenuity,
                Name = card.Name,
                Revive = card.Revive,
                Science = card.Science,
                Type = card.Type,
            };

            return model;
        }
       */


        public int Id { get; set; } // unique id 
        public CardState State { get; set; }
        public Player Owner { get; set; }
        public SGCard Card { get; set; }


        public CardModel()
        {

        }
        public CardModel(SGCard card)
        {
            this.Card = card;
        }




        public override string ToString()
        {
            return State.ToString();
        }

    }


}
