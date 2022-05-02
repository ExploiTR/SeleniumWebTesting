using SeleniumBase;


namespace WAY2Automation.Widgets
{
    internal class Slider : SelActions
    {
        public void start(bool contd)
        {

            open("https://www.way2automation.com/way2auto_jquery/slider.php#load_box");

            //not working rn : page broken

            exit();

            if (contd)
            {
                new Tabs().start(contd);
            }
        }
    }
}
