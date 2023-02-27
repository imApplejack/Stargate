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

                if(questCurrentPlayer == gameState.GetHeroPlayer())
                {

                    switch (myEvent.Type)
                    {

                        case EventType.PLAYCARD:
                            SendEvent(gameState.PlayHeroCard((PlayCardEvent)myEvent));
                            SendEvent(new StargateResult() { StargateResultType = StargateResultType.ChangePlayerAttr, attr = ((PlayCardEvent)myEvent).Sender });
                            questPhasePass[questCurrentPlayer] = false;
                            break;
                        case EventType.ASSIGNCHAR:
                            SendEvent(gameState.AssignHeroChar((AssignCharEvent)myEvent));
                            questPhasePass[questCurrentPlayer] = false;
                            break;
                        case EventType.PASS:
                            questPhasePass[questCurrentPlayer] = true;
                            break;
                        default: throw new StateResultException(StateResult.STOP);

                    }

                }
                else
                {

                    switch (myEvent.Type)
                    {

                        case EventType.PLAYCARD:
                            SendEvent(gameState.PlayMonsterBoss((PlayCardEvent)myEvent));
                            SendEvent(new StargateResult() { StargateResultType = StargateResultType.ChangePlayerAttr, attr = ((PlayCardEvent)myEvent).Sender });
                            questPhasePass[questCurrentPlayer] = false;
                            break;
                        case EventType.ASSIGNCHAR:
                            SendEvent(gameState.AssignVillanChar((AssignCharEvent)myEvent));
                            questPhasePass[questCurrentPlayer] = false;
                            break;
                        case EventType.PASS:
                            questPhasePass[questCurrentPlayer] = true;
                            //GD.Print((PassEvent)myEvent);
                            break;
                        default: throw new StateResultException(StateResult.STOP);

                    }
                }

               
                questCurrentPlayer = gameState.GetOtherPlayer(questCurrentPlayer);

                if ( !questPhasePass[gameState.CurrentPlayer] || !questPhasePass[gameState.GetEnemyPlayer()])
                {
                    //GD.Print("STOP MACHINE A ETAT");
                    Debug.WriteLine("STOP MACHINE A ETAT");
                    throw new StateResultException(StateResult.STOP);
                }
                else
                {
                    Debug.WriteLine("CONTINUE MACHINE A ETAT");
                    //GD.Print("CONTINUE MACHINE A ETAT");
                }


                
            }
            else
            {
                throw new StateResultException(StateResult.STOP);
            } 



        }

            

          


        
    }
}
