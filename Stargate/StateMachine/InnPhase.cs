using Stargate.Stargate;
using Stargate.Stargate.Enum;
using Stargate.Stargate.StateMachine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.StateMachine
{
    public class InnPhase : StargatePhase
    {

        public InnPhase(GameState gs) : base(gs)
        {
            AddAction(INNPhaseAbilities)
                   .AddAction(FailQuestInBottom)
                   .AddAction(Mp0)
                   .AddAction(ReadyAllStoppedCardsAndStopAllkosCards)
                   .AddAction(new DrawUpTo8Phase(gs))
                   .AddAction(EnnemyProcessMPPhase);
        }


        public override void InitSG()
        {
          
        }


        public void INNPhaseAbilities(StateEvent e = null)
        {
            Debug.Print("INNPhaseAbilities");
        }

        public void FailQuestInBottom(StateEvent e = null)
        {
            gameState.PlaceAllFailedQuestInBottomOfLibrary();
        }

        public void Mp0(StateEvent e = null)
        {
            gameState.player1.Energy = 0;
            gameState.player2.Energy = 0;
        }

        public void ReadyAllStoppedCardsAndStopAllkosCards(StateEvent e = null)
        {
            gameState.ReadyAllStoppedCardsAndStopAllKOCards();
        }

        public void EnnemyProcessMPPhase(StateEvent e = null)
        {
           
            //Debug.Print("EnnemyProcessMPPhase");

            gameState.SwitchPlayersRole();
            AddAction(new GameLoop(gameState));

        }

    }
}
