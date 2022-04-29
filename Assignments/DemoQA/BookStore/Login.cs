using SeleniumBase;


namespace BookStore
{
    internal class Login : SelActions
    {
        private static readonly string u_name = "BassettiTest";
        private static readonly string u_password = "Bassetti@2022";
        public void start()
        {
            open("https://demoqa.com/login");

            setInput();
            login();
            explore();

            exit();
        }

        private void explore()
        {
            new BookStore().explore(getDriver());
        }

        private void login()
        {
            FindID("login").Click();
            wait(2500);
        }

        private void setInput()
        {
            FindID("userName").SendKeys(u_name);
            FindID("password").SendKeys(u_password);
        }
    }
}
