using Stargate.Stargate;
using Stargate.Stargate.Enum;
using Stargate.Stargate.Event;
using Stargate.Stargate.Result;
using Stargate.Stargate.StateMachine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.StateMachine
{
    public class InitPhase : StargatePhase 
    {

        public InitPhase(GameState gs) : base (gs)
        {
            this.AddAction(new DrawUpTo8Phase(gs))
                .AddAction(ChooseParty)
                .AddAction(ChoosePartyEvent)
                .AddAction(new GameLoop(gs))
                ;
        }

        public void ChooseParty(StateEvent e = null)
        {
            SendEvent(new ChooseCardResult() { player = gameState.GetEnemyPlayer(), cards = gameState.CardRepository.GetPlayerTeamCharactersReady(gameState.CurrentPlayer) });
        }

        public void ChoosePartyEvent(StateEvent e = null)
        {

            if (e == null || ((StargateEvent )e).Type != EventType.SELECTCARD)
            {
                throw new StateResultException(StateResult.STOP);
            }
            else {
                SelectCardEvent sle = (SelectCardEvent)e;
                sle.cardModel.State = CardState.Stop;
                SendEvent(new StargateResult() { actionResult = ActionResult.Success, StargateResultType = StargateResultType.ChangeCard, attr = sle.cardModel });
            }
        }
    }

}
