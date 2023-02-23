using Stargate.Stargate;
using Stargate.Stargate.Enum;
using Stargate.Stargate.Event;
using Stargate.Stargate.StateMachine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.StateMachine
{

    public enum StateResult
    {      
      SUCCESS,
      STOP
    }

    public class StateResultException : Exception
    {
        public StateResult response;
        public StateResultException(StateResult response)
        {
            this.response = response;
        }
    }

}
