using Stargate.Stargate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate.SGGodot
{
    public class MappingMVC
    {

        Dictionary<CardModel, GDCard> Mapping = new Dictionary<CardModel, GDCard>();

        void add(CardModel CardModel, GDCard gDCard)
        {
            Mapping.Add(CardModel, gDCard);
        }

        GDCard get(CardModel CardModel)
        {
            return Mapping[CardModel];
        }


    }
}
