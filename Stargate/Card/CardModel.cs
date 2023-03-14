using Stargate.Repository;
using Stargate.Stargate.Enum;
using Stargate.Stargate.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.Stargate.Card
{

    public class CardModel
    {


        public GameState GameState { get; set; }

        public List<CardModel> boosts = new List<CardModel>();

        public bool HasBoost()
        {
            return boosts.Count > 0;
        }
        
        
        public virtual bool PlayCardAssert(Player player)
        {
            return (GameState.CardRepository.IsInHand(player, this) && player.Energy >= this.Card.Cost);
        }

        public virtual void PlayCardCost(Player player)
        {
            player.Energy -= this.Card.Cost;
        }


        public virtual void PlayCardAction()
        {
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

      
    }


}
