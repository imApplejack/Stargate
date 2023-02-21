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
    public class QuestPhase : Phase, IPhase
    {
        public QuestPhase(GameState gameState = null) : base(gameState)
        {
        }


        public override void Run()
        {
            SendEvent(gameState.CardService.PlayMission(gameState.CurrentPlayer));
        }



        public override void ProcessEvent(StargateEvent myEvent)
        {

            //Godot.GD.Print(myEvent);
            switch (myEvent.Type) {
                    
                case EventType.PLAYCARD:

                    StargateResult  sr = gameState.CardService.PlayCard((PlayCardEvent)myEvent);
                    GD.Print(sr);
                    SendEvent(sr);
                    SendEvent(new StargateResult() { StargateResultType = StargateResultType.ChangePlayerAttr, attr = ((PlayCardEvent)myEvent).player });

                    break;


                case EventType.ASSIGNCHAR:
                    SendEvent(gameState.CardService.AssignChar((AssignCharEvent)myEvent));
                    break;


                case EventType.PASS:
                    //GD.Print((PassEvent)myEvent);
                    break;



            }


        }


    }
}
