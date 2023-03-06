using Stargate.Stargate.Card.Interface;
using Stargate.Stargate.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.Stargate.Card
{
    public  class MissionModel : CardModel , ISGSkill
    {
        
        
        public int getMissionDifficulty()
        {
            return (int)GetSkill(GetMissionSkill());
        }
        
        public Skill GetMissionSkill()
        {
            if (Card.Ingenuity != null) { return Skill.Ingenuity; }
            else if (Card.Combat != null) { return Skill.Combat; }
            else if (Card.Science != null) { return Skill.Science; }
            else if (Card.Culture != null) { return Skill.Culture; }
            else { return Skill.None; }
        }
        public int? GetSkill(Skill skill)
        {
            try
            {
                switch (skill)
                {
                    case Skill.Ingenuity: return Card.Ingenuity;
                    case Skill.Combat: return Card.Combat;
                    case Skill.Science: return Card.Science;
                    case Skill.Culture: return Card.Culture;
                    default: return null;
                }
            }
            catch { return null; }
        }
    }
}
