using Godot;
using Stargate.Stargate;
using Stargate.Stargate.Enum;
using Stargate.Stargate.Event;
using Stargate.Stargate.StateMachine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.StateMachine
{
    public class QuestPhase : StargatePhase
    {


        public QuestPhase(GameState gs) : base(gs)
        {
           
        }


        private Dictionary<Player, bool> questPhasePass = new Dictionary<Player, bool>();

        private Player questCurrentPlayer;


        public override void InitSG()
        {
            AddAction(PlayMission)
            .AddAction(PlayAction)
            ;

            questCurrentPlayer = gameState.CurrentPlayer;
            questPhasePass = new Dictionary<Player, bool>() { [gameState.CurrentPlayer] = false, [gameState.GetEnemyPlayer()] = false };


        }


        public void PlayMission(StateEvent e = null)
        {
            SendEvent(gameState.PlayMission(gameState.CurrentPlayer));
        }



        public void PlayAction(StateEvent e = null)
        {

            //GD.Print("Questphase playaction");
            // throw new StateResultException(StateResult.STOP);


            StargateEvent myEvent = (StargateEvent)e;


            if (myEvent.Sender == questCurrentPlayer)
            {

                switch (myEvent.Type)
                {

                    case EventType.PLAYCARD:

                        StargateResult sr = gameState.PlayCard((PlayCardEvent)myEvent);
                        //GD.Print(sr);
                        SendEvent(sr);
                        SendEvent(new StargateResult() { StargateResultType = StargateResultType.ChangePlayerAttr, attr = ((PlayCardEvent)myEvent).Sender });

                        break;


                    case EventType.ASSIGNCHAR:
                        SendEvent(gameState.AssignChar((AssignCharEvent)myEvent));
                        break;


                    case EventType.PASS:
                        //GD.Print((PassEvent)myEvent);
                        break;

                }

                questCurrentPlayer = gameState.GetOtherPlayer(questCurrentPlayer);

                throw new StateResultException(StateResult.STOP);
               

            }
        }

            

          


        
    }
}
