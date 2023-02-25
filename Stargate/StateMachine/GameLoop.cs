using Stargate.Stargate;
using Stargate.Stargate.Enum;
using Stargate.Stargate.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.StateMachine
{
    public class GameLoop : StargatePhase
    {

        public GameLoop(GameState gs) : base(gs)
        {
            AddAction(new MPPhase(gs))
            .AddAction(new QuestPhase(gs))
            ;
        }

        

        /*
        public MPPhase(GameState gameState = null) : base(gameState)
        {

        }

        public override void Run() {


            // @todo process main phase abilities


            gameState.CurrentPlayer.Energy = 3; // RG à ajouter + joueur 2 
            SendEvent(new StargateResult() {StargateResultType = StargateResultType.ChangePlayerAttr , attr = gameState.CurrentPlayer});

            gameState.GetEnemyPlayer().Energy = 3; // RG à ajouter + joueur 2 
            SendEvent(new StargateResult() { StargateResultType = StargateResultType.ChangePlayerAttr, attr = gameState.GetEnemyPlayer() });



            PopAndNewPhase(new QuestPhase());

        }
        */

    }
}
