using OpenQA.Selenium;
using SeleniumBase;

namespace AutomationPractice.Homepage
{
    internal class TestSearchbar : SelActions
    {
        public TestSearchbar()
        {
            open("http://automationpractice.com/index.php");

            testInput("T-Shirt");
        }

        private void testInput(string v)
        {
            FindID("search_query_top").SendKeys(v);

            while (!elementExists(By.XPath("//*[@class='ac_results']")))
            {
                wait_5();
            }

            var results = FindAllBy(By.XPath("//*[@class='ac_results']//li"));

            if (results.Count > 0)
            {
                if (results[0].Displayed)
                {
                    results[0].Click();
                }
            }
        }
    }
}
