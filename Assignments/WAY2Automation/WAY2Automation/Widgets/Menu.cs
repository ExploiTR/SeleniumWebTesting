using SeleniumBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAY2Automation.Widgets
{
    internal class Menu : SelActions
    {
        public void start(bool contd) {

            open("https://www.way2automation.com/way2auto_jquery/menu.php");

            //not working rn : page broken

            exit();

            if (contd) {
                new Slider().start(contd);
            }
        }
    }
}
