using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    internal class Runner
    {
        static void Main(string[] args)
        {
            bool chain = false;

            new Home().start(chain);
        }
    }
}
