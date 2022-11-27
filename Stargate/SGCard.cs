using Stargate.Stargate.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate
{
    public class SGCard
    {
        public string Id { get; set; } // hash
        public string Name { get; set; } = String.Empty;
        public CardType Type { get; set; } = CardType.NONE;
        public int Cost { get; set; } = 0;
        public int? Culture { get; set; } = null;
        public int? Science { get; set; } = null;
        public int? Combat { get; set; } = null;
        public int? Ingenuity { get; set; } = null;

        public int? Revive { get; set; } = null;
    }
}
