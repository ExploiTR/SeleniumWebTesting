using SeleniumBase;

namespace WAY2Automation.Widgets
{
    internal class Tabs : SelActions
    {
        public void start(bool contd)
        {

            open("https://www.way2automation.com/way2auto_jquery/tabs.php#load_box");

            //not working rn : page broken

            exit();

            if (contd)
            {
                new Tooltips().start();
            }
        }
    }
}
