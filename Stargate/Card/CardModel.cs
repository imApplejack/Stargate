using Stargate.Stargate.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.Stargate.Card
{

    public class CardModel
    {

        public List<CardModel> boosts = new List<CardModel>();

        public bool HasBoost()
        {
            return boosts.Count > 0;
        }

        public void AddBoost(CardModel boost)
        {
            boosts.Add(boost);
        }

        // ici probablement typer avec boostype pour les enlevages en fonctions des phases
        public void ClearBoosts()
        {
            boosts = new List<CardModel>();
        }


        public int Id { get; set; } // unique id 
        public CardState State { get; set; }
        public Player Owner { get; set; }
        public SGCard Card { get; set; }


        public CardModel()
        {

        }
        public CardModel(SGCard card)
        {
            Card = card;
        }




        public override string ToString()
        {
            return "Id : " + Id + "  State : " + State;
        }

        public static implicit operator CardModel(List<CardModel> v)
        {
            throw new NotImplementedException();
        }
    }


}
