using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SeleniumBase;

namespace Interaction
{
    internal class Selectable : SelActions
    {
        public void start(bool continue_)
        {
            open("https://demoqa.com/selectable");

            testNormalList();
            testGridList();

            exit();

            if (continue_)
            {
                new Resizable().start(continue_);
            }
        }

        private void testGridList()
        {
            FindID("demo-tab-grid").Click();
            wait(500);

            var item1 = FindAllBy(By.XPath("//div[@id='demo-tabpane-grid']//li[contains(@class,'list-group-item')]"));

            Actions actions = getAction();

            moveToElementAndClick(item1[0]);
            moveToElementAndClick(item1[1]);
            moveToElementAndClick(item1[3]);
            moveToElementAndClick(item1[4]);
            moveToElementAndClick(item1[5]);
            moveToElementAndClick(item1[8]);
            moveToElementAndClick(item1[3]);
            moveToElementAndClick(item1[4]);
            moveToElementAndClick(item1[6]);
            moveToElementAndClick(item1[2]);
            moveToElementAndClick(item1[1]);
            moveToElementAndClick(item1[5]);
            moveToElementAndClick(item1[0]);
            moveToElementAndClick(item1[7]);
            moveToElementAndClick(item1[2]);
            moveToElementAndClick(item1[1]);

            actions.Build().Perform();
        }

        private void testNormalList()
        {
            var item1 = FindAllBy(By.XPath("//div[@id='demo-tabpane-list']//li[contains(@class,'list-group-item')]"));

            Actions actions = getAction();

            moveToElementAndClick(item1[0]);
            moveToElementAndClick(item1[1]);
            moveToElementAndClick(item1[2]);
            moveToElementAndClick(item1[3]);
            moveToElementAndClick(item1[0]);
            moveToElementAndClick(item1[1]);
            moveToElementAndClick(item1[2]);
            moveToElementAndClick(item1[3]);

            actions.Build().Perform();
        }
    }
}
