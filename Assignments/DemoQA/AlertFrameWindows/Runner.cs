using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlertFrameWindows
{
    internal class Runner
    {
        static void Main(string[] args)
        {
            bool chain = true;

            new Windows().start(chain);
            //new Alerts().start(chain);
            //new Frames().start(chain);
            //new NestedFrames().start(chain);
            //new Modal().start(chain);
        }
    }
}
