using Godot;
using Stargate.Repository;
using Stargate.Stargate;
using Stargate.Stargate.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Stargate
{
    public class Player
    {


        public int id { get; set; }

        public int Energy { get; set; }

        public GameState gameState { get; set; }

        public Player()
        {

        }


        public int TotalExperience()
        {
            return gameState.TotalExperience(this);
        }

        public int VictoryTotal()
        {
            return gameState.VictoryTotal(this);
        }

        public int Library()
        {
            return gameState.CardRepository.Libraries[this].Count;
        }

       
    }
}
