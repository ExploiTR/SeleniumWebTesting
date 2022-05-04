using OpenQA.Selenium;
using SeleniumBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.Homepage
{
    internal class TestCart : SelActions
    {
        public TestCart()
        {
            open("http://automationpractice.com/index.php");

            addRandomStuffToCart();
            testCart();
        }

        private void testCart()
        {
            scrollPage(0, -200);

            hoverOnto(FindXPath("//a[@title='View my shopping cart']"));

            wait2s();

            clickByJS(FindAllBy(By.XPath("//dt//span[@class='remove_link']"))[0]);

            wait1s();

            clickByJS(FindID("button_order_cart"));
        }

        private void addRandomStuffToCart()
        {
            var cards = FindAllBy(By.XPath("//*[@id='homefeatured']//li"));

            var curElement = cards.Last();

            scrollForElementVisibility(curElement);

            hoverOnto(curElement);

            wait1s();

            clickByJS(FindXPath("//*[text()='Add to cart']"));

            switchToActive();

            wait3s();

            FindXPath("//*[@title='Close window']").Click();

            wait1s();

            switchToDefault();
        }
    }
}
