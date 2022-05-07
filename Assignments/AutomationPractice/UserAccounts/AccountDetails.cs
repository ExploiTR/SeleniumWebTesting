using SeleniumBase;

namespace AutomationPractice.UserAccounts
{
    internal class AccountDetails : SelActions
    {
        public AccountDetails()
        {
            login();

            checkOrders();
            checkCredit();
            checkAddress();
            checkPInfo();
            checkWishlist();

            testLogOut();

            exit();
        }

        private void testLogOut()
        {
            FindTitleTagless("Log me out").Click();
            wait5s();
        }

        private void login()
        {
            open("http://automationpractice.com/index.php?controller=authentication&back=my-account");

            FindID("email").SendKeys("trennis.jazon@whoisox.com");
            FindID("passwd").SendKeys("demopass");

            FindID("SubmitLogin").Click();

            wait5s();
        }

        private void checkWishlist()
        {
            controlClick(FindTitleTagless("My wishlists"));
            switchToWindow(1);

            wait5s();

            close();

            switchToWindow(0);
            wait_5();
            switchToDefault();
        }

        private void checkPInfo()
        {
            controlClick(FindTitleTagless("Information"));
            switchToWindow(1);

            wait5s();

            close();

            switchToWindow(0);
            wait_5();
            switchToDefault();
        }

        private void checkAddress()
        {
            controlClick(FindTitleTagless("Addresses"));
            switchToWindow(1);

            wait5s();

            close();

            switchToWindow(0);
            wait_5();
            switchToDefault();
        }

        private void checkCredit()
        {
            controlClick(FindTitleTagless("Credit slips"));
            switchToWindow(1);

            wait5s();

            close();

            switchToWindow(0);
            wait_5();
            switchToDefault();
        }

        private void checkOrders()
        {
            controlClick(FindTitleTagless("Orders"));
            switchToWindow(1);

            wait5s();

            close();

            switchToWindow(0);
            wait_5();
            switchToDefault();
        }
    }
}
