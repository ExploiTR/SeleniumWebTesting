using NUnit.Framework;
using SeleniumBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.TestCases
{
    /*
     * 7# Test Case - Verify that 'Add to Wishlist' only works after login.
     * Steps to Automate:
     * 1. Open link http://automationpractice.com/index.php
     * 2. Move your cursor over Women's link.
     * 3. Click on sub menu 'T-shirts'.
     * 4. Mouse hover on the first product displayed.
     * 5. 'Add to Wishlist' will appear on the bottom of that product, click on it.
     * 6. Verify that error message is displayed 'You must be logged in to manage your wish list.'
     */
    class TestCase7 : SelActions
    {

        public TestCase7()
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

            scrollPage(0, 400);

            hoverOnto(FindXPath("//ul[contains(@class,'product_list')]//div[@class='product-container'][1]"));

            FindXPath("//div[@class='wishlist']").Click();
            //bug :   clickByJS(FindXPath("//div[@class='wishlist']"));

            waitForPageLoad();

            switchToActive();

            Assert.That(elementExists(XPath("//*[text()='You must be logged in to manage your wishlist.']")));
        }
    }
}
