using SeleniumBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase.GoDaddyTests
{
    class TC1 : SelActions
    {
        /*
        * 1. Test Case - Open Godaddy.com and maximize browser window.
        * Steps to Automate:
        * 1. Launch browser of your choice say., Firefox, chrome etc.
        * 2. Open this URL - https://www.godaddy.com/
        * 3. Maximize or set size of browser window.
        * 4. Close browser.
        */
        public TC1()
        {
            open("https://www.godaddy.com/");
            wait2s();
            exit();
        }
    }
}
