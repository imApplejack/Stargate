using Godot;
using Stargate.Repository;
using Stargate.Stargate;
using Stargate.Stargate.Card;
using Stargate.Stargate.Enum;
using Stargate.Stargate.Event;
using Stargate.Stargate.Result;
using Stargate.Stargate.StateMachine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.StateMachine
{
    public class Revive : StargatePhase
    {

        public Revive(GameState gs) : base(gs)
        {
            AddAction(ReviveMethod);
            
        }

        public void ReviveMethod(StateEvent e = null)
        {
            List<CardModel> ennemiesInMission = gameState.GetEnnemyPlayerAdversaryInMission();
            if (ennemiesInMission.Count > 0)
            {
                SelectCardEvent theevent = e as SelectCardEvent;

                //GD.PrintErr("revice cost : " + gameState.GetReviveCost(ennemiesInMission) + " library : " + gameState.GetEnemyPlayer().Library());
                if (theevent != null && theevent.Sender == gameState.GetEnemyPlayer() && theevent.Type == EventType.SELECTCARD && gameState.GetReviveCost(theevent.cardModel) <= gameState.GetEnemyPlayer().Library()) // taillle du deck @pas teste
                {
                    foreach (CardModel item in theevent.cardModel)
                    {
                        gameState.ChangeCardState(item, CardState.Stop);
                        gameState.MeuleUpTo(gameState.GetEnemyPlayer(), (int)item.Card.Revive);
                    }
                }
                else
                {
                    SendEvent(new ChooseCardResult() { player = gameState.GetEnemyPlayer(), cards = ennemiesInMission, Range = SelectCardEnum.UpToInfinite, Label = "Choisissez le ou les boss monster a revive" });
                    throw new StateResultException(StateResult.STOP);
                }
            }
        }

    }
}
