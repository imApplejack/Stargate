using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.Stargate.Enum
{
    public enum ActionResult
    {
        Success,
        Failure
    }

    public enum StargateResultType
    {
        ChangeCard,
    }


    public class StargateResult {
        public ActionResult actionResult { get; set; }
        public StargateResultType StargateResultType { get; set; }
        public Object attr { get; set; }



        public override string ToString()
        {
            return actionResult + " " + StargateResultType + " " + attr;
        }
    }


   

}
