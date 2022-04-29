using SeleniumBase;

namespace Elements
{
    internal class RadioButton : SelActions
    {
        public void run(bool _continue)
        {
            open("https://demoqa.com/radio-button");

            wait(500);

            clickByJS(FindID("yesRadio"));

            wait(1000);

            clickByJS(FindID("impressiveRadio"));

            wait(3000);

            exit();

            if (_continue)
                new WebTables().run(_continue);
        }
    }
}
