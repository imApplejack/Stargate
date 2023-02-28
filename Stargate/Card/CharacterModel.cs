using Stargate.Stargate.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.Stargate.Card
{
    public  class CharacterModel : CardModel
    {

        public int? GetSkill(Skill skill) {
            switch (skill)
            {
                case Skill.Ingenuity: return Card.Ingenuity;
                case Skill.Combat: return Card.Combat;
                case Skill.Science: return Card.Science;
                case Skill.Culture: return Card.Culture;
                default : return null;
            }
        }
    }
}
