using Stargate.Stargate.Card.Interface;
using Stargate.Stargate.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.Stargate.Card
{
    public  class HeroCharacterModel : CharacterModel, ISGSkill
    {
       
        public List<MissionModel> glyphsEarned = new List<MissionModel>();


        public int GetVictoryTotal()
        {
            int retour = 0;
            foreach (MissionModel item in glyphsEarned)
            {
                retour += (int)item.Card.Experience;
            }
            return retour;
        }

        public int CountGlyph()
        {
            return glyphsEarned.Count;
        }

    }
}
