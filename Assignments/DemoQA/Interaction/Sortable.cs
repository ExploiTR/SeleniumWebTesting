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
    internal class Sortable : SelActions
    {
        public void start(bool continue_)
        {
            open("https://demoqa.com/sortable");

            testNormalList();
            testGridList();

            exit();

            if (continue_) {
                new Selectable().start(continue_);
            }
        }

        private void testGridList()
        {
            FindID("demo-tab-grid").Click();
            wait(500);

            var item1 = FindAllBy(By.XPath("//div[@id='demo-tabpane-grid']//div[contains(@class,'list-group-item')]"));

            getAction().MoveToElement(item1[0])
                .ClickAndHold()
                .MoveToElement(item1[3])
                .MoveToElement(item1[4])
                .MoveToElement(item1[5])
                .MoveToElement(item1[8])
                .MoveToElement(item1[6])
                .MoveToElement(item1[2])
                .MoveToElement(item1[1])
                .Release()
                .Build()
                .Perform();
        }

        private void testNormalList()
        {
            var item1 = FindAllBy(By.XPath("//div[@id='demo-tabpane-list']//div[contains(@class,'list-group-item')]"));

            getAction().MoveToElement(item1[1])
                .ClickAndHold()
                .MoveToElement(item1[3])
                .Release()
                .MoveToElement(item1[4])
                .ClickAndHold()
                .MoveToElement(item1[5])
                .Release()
                .MoveToElement(item1[0])
                .ClickAndHold()
                .MoveToElement(item1[3])
                .Release()
                .Build()
                .Perform();
        }
    }
}
