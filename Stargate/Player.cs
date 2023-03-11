using Godot;
using Stargate.Stargate;
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

        public Player() { 
        

        }
    }
}
