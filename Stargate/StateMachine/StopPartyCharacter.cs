using Stargate.Stargate;
using Stargate.Stargate.Enum;
using Stargate.Stargate.Event;
using Stargate.Stargate.Result;
using Stargate.Stargate.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.StateMachine
{
    public class StopPartyCharacter : StatePhase, IPhase
    {

        // public event EventHandler StargateResultHandler;

        /*

        public StopPartyCharacter(GameState gameState = null) : base(gameState)
        {
        }

        public override void Run()
        {
            SendEvent(new ChooseCardResult() { player = gameState.GetEnemyPlayer(), cards = gameState.CardService.CardRepository.GetPlayerTeamCharactersReady(gameState.CurrentPlayer) });
        }


        public override void ProcessEvent(StargateEvent myEvent)
        {

            if(myEvent.Type == EventType.SELECTCARD)
            {
                SelectCardEvent e = (SelectCardEvent)myEvent;
                e.cardModel.State = CardState.Stop;

                SendEvent(new StargateResult() { actionResult = ActionResult.Success, StargateResultType = StargateResultType.ChangeCard, attr = e.cardModel });


                PopAndNewPhase(new MPPhase());
            }


           
        }
        */
    }
}
