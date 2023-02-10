using Stargate.Service;
using Stargate.Stargate.Enum;
using Stargate.Stargate.Event;
using Stargate.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.Stargate
{

    

    public class GameState
    {


        public Random random = null;

        public SGMissionEvent Mission { get; set; } = null;
        public Player CurrentPlayer { get; set; } = null;

        public Player player1 { get; set; } = null;
        public Player player2 { get; set; } = null;

        public CardService CardService { get; set; }

        public Stack<Phase> GameStack { get; set; }

        public event EventHandler StargateResultHandler;


        public GameState()
        {

        }


       public Player GetEnemyPlayer()
        {
            if(CurrentPlayer == player1)
            {
                return player2;
            }
            else
            {
                return player1;
            }
        }


        public Player GetHeroPlayer()
        {
            return CurrentPlayer;
        }


        public void InitGame(int seed)
        {
            random = new Random(seed);
            CurrentPlayer = player1;
            GameStack = new Stack<Phase>();
            GameStack.Push(new InitPhase(this));
            GameStack.Peek().Run();
        }


        public void Update() { }

        public void ProcessEvent(StargateEvent myEvent)
        {
            GameStack.Peek().ProcessEvent(myEvent);
        }

        public void ForwardEvent(StargateResult e)
        {
            StargateResultHandler?.Invoke(this, e);
        }

        
    }



}

       




