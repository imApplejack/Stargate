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
            this.
                AddAction(Shuffle)
                 .AddAction(new DrawUpTo8Phase(gs))
                .AddAction(ChoosePartyEvent)
                .AddAction(new GameLoop(gs))
                ;
        }


        public void Shuffle(StateEvent e = null)
        {
            gameState.ShuffleDecksAndLibraries();
        }

        public void ChoosePartyEvent(StateEvent e = null)
        {

            SelectCardEvent sle = e as SelectCardEvent;
            if (sle == null || sle.Type != EventType.SELECTCARD || sle.cardModel.Count != 1)
            {
                SendEvent(new ChooseCardResult() { player = gameState.GetEnemyPlayer(), cards = gameState.CardRepository.GetPlayerTeamCharactersReady(gameState.CurrentPlayer), Label = "choisissez une personne a stopper" });
                throw new StateResultException(StateResult.STOP);
            }
            else 
                sle.cardModel[0].State = CardState.Stop;
                SendEvent(new StargateResult() { actionResult = ActionResult.Success, StargateResultType = StargateResultType.ChangeCard, attr = sle.cardModel[0] });
            }
        }
    

}
