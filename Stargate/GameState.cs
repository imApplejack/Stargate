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

        public Player CurrentPlayer { get; set; } = null;

        public Player player1 { get; set; } = null;
        public Player player2 { get; set; } = null;


        public CardService CardService { get; set; }

        public StateAction GameStack { get; set; }

        public event EventHandler StargateResultHandler;


        public GameState()
        {

        }




        public Player GetOtherPlayer(Player player)
        {
            if(player == GetHeroPlayer())
            {
                return GetEnemyPlayer();
            }
            return GetHeroPlayer();

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
            GameStack = new InitPhase(this);
            GameStack.Play();
        }


        public void Update() { }

        public void ProcessEvent(StargateEvent myEvent)
        {
            Godot.GD.Print(myEvent);
            GameStack.Play(myEvent);

           
        }

        public void ForwardEvent(StargateResult e)
        {
            if(e.actionResult == ActionResult.Success)
            {
                StargateResultHandler?.Invoke(this, e);
            }
           
        }

        
    }



}

       




