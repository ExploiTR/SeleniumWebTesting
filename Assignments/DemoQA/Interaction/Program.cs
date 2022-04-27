using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interaction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool chain = false;
          //  new Sortable().start(chain);
            new Selectable().start(chain);

            Console.ReadKey();
        }
    }
}
