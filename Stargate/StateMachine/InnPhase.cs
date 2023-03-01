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
           
        }


        public override void InitSG()
        {
            AddAction(INNPhaseAbilities)
                    .AddAction(FailQuestInBottom)
                    .AddAction(Mp0)
                    .AddAction(ReadyAllStoppedCardsAndStopAllkosCards)
                    .AddAction(RefillHands)
                    .AddAction(EnnemyProcessMPPhase);
        }


        public void INNPhaseAbilities(StateEvent e = null)
        {
            Debug.Print("INNPhaseAbilities");
        }

        public void FailQuestInBottom(StateEvent e = null)
        {
            Debug.Print("FailQuestInBottom");
        }

        public void Mp0(StateEvent e = null)
        {
            Debug.Print("Mp0");
        }

        public void ReadyAllStoppedCardsAndStopAllkosCards(StateEvent e = null)
        {
            Debug.Print("ReadyAllStoppedCardsAndStopAllkosCards");
        }

        public void RefillHands(StateEvent e = null)
        {
            Debug.Print("RefillHands");
        }

        public void EnnemyProcessMPPhase(StateEvent e = null)
        {
            Debug.Print("EnnemyProcessMPPhase");
        }

    }
}
