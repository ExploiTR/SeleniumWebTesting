using SeleniumBase;

namespace AutomationPractice.TestCases
{
    class TestCase6 : SelActions
    {
        /*
         * 6# Test Case - Automate end-to-end "Buy Product" feature of the e-commerce website.
         * Steps to Automate:
         * 1. Open link http://automationpractice.com/index.php
         * 2. Login to the website.
         * 3. Move your cursor over Women's link.
         * 4. Click on sub menu 'T-shirts'.
         * 5. Mouse hover on the second product displayed.
         * 6. 'More' button will be displayed, click on 'More' button.
         * 7. Increase quantity to 2.
         * 8. Select size 'L'
         * 9. Select color.
         * 10. Click 'Add to Cart' button.
         * 11. Click 'Proceed to checkout' button.
         * 12. Complete the buy order process till payment.
         * 13. Make sure that Product is ordered.
         */

        public TestCase6()
        {
            open("http://automationpractice.com/index.php");

            doTest();

            exitPrompt();
        }

        private void doTest()
        {
            hoverOnto(FindTextTagless("Women"));

            clickByJS(FindXPath("//*[text()='Tops']//ancestor::li//*[text()='T-shirts']"));

            waitForPageLoad();


        }
    }
}
