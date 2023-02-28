using Stargate.Stargate.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.Stargate.Card
{
    public  class MissionModel : CardModel
    {

        public Skill GetMissionSkill()
        {
            if (Card.Ingenuity != null) { return Skill.Ingenuity; }
            else if (Card.Combat != null) { return Skill.Combat; }
            else if (Card.Science != null) { return Skill.Science; }
            else if (Card.Culture != null) { return Skill.Culture; }
            else { return Skill.None; }
        }
    }
}
