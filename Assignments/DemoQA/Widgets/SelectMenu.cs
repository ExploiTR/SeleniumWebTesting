using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using SeleniumBase;


namespace Widgets
{
    internal class SelectMenu : SelActions
    {
        public void start()
        {
            open("https://demoqa.com/select-menu");

            pickOption();
            pickTitle();
            pickColor();
            pickMulColor();
            testStdMulSel();

            exit();
        }

        private void testStdMulSel()
        {
            getAction().KeyDown(Keys.LeftControl)
                .MoveToElement(FindAllBy(By.XPath("//select[@id='cars']//option"))[1])
                .Click()
                .MoveToElement(FindAllBy(By.XPath("//select[@id='cars']//option"))[0])
                .Click()
                .Release()
                .Build()
                .Perform();

            wait(1000);
        }

        private void pickMulColor()
        {
            FindXPath("//div[text()='Select...']").Click();

            FindXPath("//input[@id='react-select-4-input']")
                .SendKeys(Keys.ArrowDown + Keys.Enter +
                Keys.ArrowDown + Keys.Enter +
                Keys.ArrowDown + Keys.Enter +
                Keys.ArrowDown + Keys.Enter);

            wait(1000);
        }

        private void pickColor()
        {
            getAction().Click(FindID("oldSelectMenu"))
                .SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);

            wait(1000);
        }

        private void pickTitle()
        {
            FindXPath("//div[text()='Select Title']")
                .Click();

            wait(500);

            FindXPath("//input[@id='react-select-3-input']")
                 .SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);

            wait(1000);
        }

        private void pickOption()
        {
            FindXPath("//div[text()='Select Option']").Click();

            wait(500);

            FindXPath("//input[@id='react-select-2-input']")
                .SendKeys(Keys.ArrowDown + Keys.ArrowDown +
                Keys.ArrowDown + Keys.ArrowDown +
                Keys.ArrowDown + Keys.Enter);

            wait(1000);
        }
    }
}
