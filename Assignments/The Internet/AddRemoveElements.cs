using SeleniumBase;

namespace The_Internet
{
    internal class AddRemoveElements : SelActions
    {
        public AddRemoveElements()
        {
            open("https://the-internet.herokuapp.com/add_remove_elements/");

            for (int i = 0; i < 10; i++)
            {
                FindTextTagless("Add Element").Click();
                wait(250);
            }

            for (int i = 0; i < 10; i++)
            {
                FindTextTagless("Delete").Click();
                wait(250);
            }

            exit();
        }
    }
}
