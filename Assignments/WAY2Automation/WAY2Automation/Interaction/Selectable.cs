using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumBase;

namespace WAY2Automation.Interaction
{
    internal class Selectable : SelActions
    {
        public void start(bool contd) {

            open("https://www.way2automation.com/way2auto_jquery/selectable.php#load_box");

            //broken page

            exit();

            if (contd) {
                new Sortable().start(contd);
            }
        }

        private void testNormal()
        {
            throw new NotImplementedException();
        }
    }
}
