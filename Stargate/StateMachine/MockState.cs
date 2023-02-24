using Stargate.Stargate;
using Stargate.Stargate.Event;
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
    public class  MockState : StateAction
    {

        public override void Play(StateEvent e = null)
        {
            Debug.WriteLine("mock state");
        }

    }

}
