using OpenQA.Selenium;
using SeleniumBase;
using System.Linq;

namespace AutomationPractice.Homepage
{
    internal class TestMenus : SelActions
    {
        public TestMenus()
        {
            open("http://automationpractice.com/index.php");

            //testThumbs();

            //testTab0();

            //testTab1();

            //testBestSellers();

            testCards();

            exit();
        }

        private void testThumbs()
        {
            FindClassesTagLess("bx-prev").Click();

            wait1s();

            FindClassesTagLess("bx-next").Click();
        }

        private void testCards()
        {
            var cards = FindAllBy(By.XPath("//*[@id='homefeatured']//*[@class='product-container']"));

            var curElement = cards.Last();

            scrollForElementVisibility(curElement);

            testAddtoCart(curElement);

            testQuickView(curElement, cards.Count);

        }

        private void testQuickView(IWebElement curElement, int count)
        {
            hoverOnto(FindAllBy(By.XPath("//ul[@id='homefeatured']//div"))[count - 1]);

            wait_5();

            switchToActive();

            clickByJS(FindXPath("//*[@class='quick-view']"));

            wait3s();

            while (elementExists(By.Id("fancybox-loading")))
            {
                //wait+
            }

            wait1s();

            switchToActive();

            switchToFrame(1);

            testQuickView_Thumbs();

            testQuickView_Inputs();
        }

        private void testQuickView_Inputs()
        {
            FindID("quantity_wanted").SendKeys("5");

            wait1s();

            FindClassesTagLess("icon-minus").Click();

            wait1s();

            FindClassesTagLess("icon-plus").Click();

            wait1s();

            FindID("uniform-group_1").Click();

            wait1s();

            getAction()
                .SendKeys(Keys.ArrowDown + Keys.Enter).Perform();

            wait1s();

            var colors = FindAllBy(By.XPath("//*[@id='color_to_pick_list']//li"));

            wait1s();

            colors.Last().Click();

            wait1s();

            FindID("add_to_cart").Click();

            wait5s();
            wait5s();
            wait5s();

            switchToActive();

            wait5s();

            FindXPath("//*[@title='Continue shopping']").Click();

            switchToDefault();
        }

        private void testQuickView_Thumbs()
        {
            var elems = FindAllBy(By.XPath("//*[@id='thumbs_list_frame']//li"));

            foreach (var elem in elems)
            {
                elem.Click();
                wait1s();
            }
        }

        private void testAddtoCart(IWebElement curElement)
        {
            hoverOnto(curElement);

            wait1s();

            clickByJS(FindXPath("//*[text()='Add to cart']"));

            switchToActive();

            wait3s();

            FindXPath("//*[@title='Close window']").Click();

            wait1s();

            switchToDefault();
        }

        private void testBestSellers()
        {
            FindTextTagless("Best Sellers").Click();
            wait3s();
        }

        private void testTab1()
        {
            hoverOnto(FindXPath("//*[text()='Women']//ancestor::ul/li[2]"));

            switchToActive();

            controlClick(FindXPath("//li[@class='sfHover']//*[text()='Casual Dresses']"));

            controlClick(FindXPath("//li[@class='sfHover']//*[text()='Evening Dresses']"));

            controlClick(FindXPath("//li[@class='sfHover']//*[text()='Summer Dresses']"));

            wait3s();

            swapWindows();

            switchToDefault();
        }

        private void testTab0()
        {
            hoverOnto(FindTextTagless("Women"));

            switchToActive();

            controlClick(FindXPath("//*[text()='Tops']//ancestor::li//*[text()='T-shirts']"));

            controlClick(FindXPath("//*[text()='Tops']//ancestor::li//*[text()='Blouses']"));

            controlClick(FindXPath("//*[text()='Tops']//ancestor::li//*[text()='Casual Dresses']"));

            controlClick(FindXPath("//*[text()='Tops']//ancestor::li//*[text()='Evening Dresses']"));

            controlClick(FindXPath("//*[text()='Tops']//ancestor::li//*[text()='Summer Dresses']"));

            wait3s();

            swapWindows();

            switchToDefault();
        }

        void swapWindows()
        {
            for (int i = getDriver().WindowHandles.Count - 1; i > 0; i--)
            {
                switchToWindow(i);
                wait2s();
                close();
            }
            switchToWindow(0);
        }
    }
}
