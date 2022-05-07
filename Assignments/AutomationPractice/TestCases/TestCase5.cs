using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumBase;

namespace AutomationPractice.TestCases
{
    /*
     * 5# Test Case - Automate 'Search Product' feature of e-commerce website with Selenium.
     * Steps to Automate:
     * 1. Open link http://automationpractice.com/index.php
     * 2. Move your cursor over Women's link.
     * 3. Click on sub menu 'T-shirts'
     * 4. Get Name/Text of the first product displayed on the page.
     * 5. Now enter the same product name in the search bar present on top of page and click search button.
     * 6. Validate that same product is displayed on searched page with same details which were displayed on T-Shirt's page.
     */

    internal class TestCase5 : SelActions
    {
        public TestCase5()
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

            string p_name = getTextJS(FindXPath("//*[contains(@class,'product_list') and contains(@class,'grid')]//*[@class='product-name']"));
            string price = getTextJS(FindXPath("//*[contains(@class,'product_list') and contains(@class,'grid')]//*[@itemprop='price']"));

            FindID("search_query_top").SendKeys(p_name + Keys.Enter);

            waitForPageLoad();

            string p_name_verify = getTextJS(FindXPath("//*[contains(@class,'product_list') and contains(@class,'grid')]//*[@class='product-name']"));
            string price_verify = getTextJS(FindXPath("//*[contains(@class,'product_list') and contains(@class,'grid')]//*[@itemprop='price']"));

            Assert.AreEqual(p_name, p_name_verify);
            Assert.AreEqual(price, price_verify);
        }
    }
}
