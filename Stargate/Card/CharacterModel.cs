using Stargate.Stargate.Card.Interface;
using Stargate.Stargate.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.Stargate.Card
{
    public  class CharacterModel : CardModel, ISGSkill
    {


        private List<CardModel> boosts = new List<CardModel>();

        public int? GetSkill(Skill skill)
        {
            try
            {
                switch (skill)
                {
                    case Skill.Ingenuity: return Card.Ingenuity + boosts.Count;
                    case Skill.Combat: return Card.Combat + boosts.Count;
                    case Skill.Science: return Card.Science + boosts.Count;
                    case Skill.Culture: return Card.Culture + boosts.Count;
                    default : return null;
                }
            }
            catch { return null; } 
        }


        public bool HasBoost()
        {
           return boosts.Count > 0;
        }

        public void AddBoost(CharacterModel boost)
        {
            boosts.Add(boost);
        }

        public void ClearBoosts()
        {
            boosts = new List<CardModel>();
        }

    }
}
