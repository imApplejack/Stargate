using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate
{
    public class SGCharacter
    {


        public int Culture { get; set; } = 0;
        public int Science { get; set; } = 0;
        public int Combat { get; set; } = 0;
        public int Ingenuity { get; set; } = 0;



        //public string Name { get; set; }

        public override string ToString()
        {
            return Culture + " "  + Science + " " + Combat + "" + Ingenuity;
        }
    }

   
}
