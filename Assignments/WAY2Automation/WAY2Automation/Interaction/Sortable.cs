using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumBase;

namespace WAY2Automation.Interaction
{
    internal class Sortable : SelActions
    {
        public void start(bool contd) {

            open("https://www.way2automation.com/way2auto_jquery/sortable.php#load_box");


            //broken page
            exit();
        }
    }
}
