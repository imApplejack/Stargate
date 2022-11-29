using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stargate
{
    public class SGCard
    {
        uint Reference { get; set; }

        public void TestHandler(object sender, EventArgs e)
        {
            Console.WriteLine(e);


        }

    }
}
