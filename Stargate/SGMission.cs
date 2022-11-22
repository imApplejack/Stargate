using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate 
{
    public class SGMission : SGEntity
    {
        public int Culture { get; set; } = 0;
        public int Science { get; set; } = 0;
        public int Combat { get; set; } = 0;
        public int Ingenuity { get; set; } = 0;

    }
}
