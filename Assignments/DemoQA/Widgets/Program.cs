using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Widgets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool chain = true;

            new Accordian().start(chain);
            //new AutoComplete().start(chain);
            //new DatePickerInput().start(chain);
            //new Slider().start(chain);
            //new ProgressBar().start(chain);
            //new Tabs().start(chain);
            //new ToolTips().start(chain);
            //new Menu().start(chain);
            //new SelectMenu().start();
        }
    }
}
