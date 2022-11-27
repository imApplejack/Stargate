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

        public static event EventHandler CardModelObservable;

        public int Id { get; set; } // unique id 
        public CardState State { get; set; }
        public Player Owner { get; set; }


        public CardModel()
        {

        }
        public CardModel(SGCard card)
        {
            Card = card;
            Combat = card.Combat;
            Cost = card.Cost;
            Culture = card.Culture;
            Ingenuity = card.Ingenuity;
            Name = card.Name;
            Revive = card.Revive;
            Science = card.Science;
            Type = card.Type;
        }


        public string Name { get; set; } = String.Empty;
        public int Cost { get; set; } = 0;
        public int? Culture { get; set; } = null;
        public int? Science { get; set; } = null;
        public int? Combat { get; set; } = null;
        public int? Ingenuity { get; set; } = null;
        public int? Revive { get; set; } = null;
        public CardType Type { get; set; }

        public SGCard Card { get; set; }
        public void RefreshView()
        {
            CardModelObservable(this, new CardModelEventArgs());
        }

    }

    class CardModelEventArgs : EventArgs
    {
        public override string ToString()
        {
            return "CardModel call handler kikoo";
        }
    }

}
