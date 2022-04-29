using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;
using System.Threading;
using SeleniumBase;

namespace Elements
{
    internal class WebTables : SelActions
    {
        public void run(bool _continue)
        {
            open("https://demoqa.com/webtables");

            wait(500);

            IWebElement searchBox = FindID("searchBox");

            searchValues(searchBox);

            click(FindXPath("//span[contains(@class,'pageSizeOptions')]"));
            wait(250);
            click(FindXPath("//option[@value='20']"));

            scrollPage(0, 200);
            wait(500);

            addNewRecord();

            inputInitialValue();

            wait(500);

            click(FindID("submit"));

            wait(1000);

            #region FindAllEntries(Unused)
            /* 
             *
             * var rows = FindAllBy(By.ClassName("rt-tr-group"));
            int totalEntryCount = 0;
            foreach (IWebElement element in rows)
            {
                string text = element.FindElement(By.ClassName("rt-td")).GetAttribute("innerText").Trim();
                if (text.Equals("") || text.Contains("span"))
                {
                    break;
                }
                totalEntryCount++;
            }
            driver.FindElement(By.Id("edit-record-1")).Click();
            *   
            */
            #endregion

            editEntry();

            sendNewValues();

            wait(500);

            submit();

            wait(250);

            deleteFirstEntry();

            testSearchBoxAgain(searchBox);

            wait(3000);

            exit();

            if (_continue)
                new Buttons().run(_continue);
        }

        private void testSearchBoxAgain(IWebElement searchBox)
        {
            sendKeys(searchBox, "Nameless");
            wait(500);
            clear(searchBox);
            wait(500);
            sendKeys(searchBox, "22");
            wait(500);
            clear(searchBox);
            wait(500);
            sendKeys(searchBox, "Automation");
            wait(500);
            clear(searchBox);
        }

        private void deleteFirstEntry()
        {
            click(FindAllBy(By.XPath("//span[@title='Delete']"))[0]);
            wait(1000);
        }

        private void submit()
        {
            click(FindID("submit"));
            switchToActive();
        }

        private void addNewRecord()
        {
            click(FindID("addNewRecordButton"));
            wait(100);
            switchToActive();
        }

        private void sendNewValues()
        {
            clearAndSendKeys(FindID("firstName"), "EditedName");
            clearAndSendKeys(FindID("firstName"), "EditedName");
            clearAndSendKeys(FindID("lastName"), "Name");
            clearAndSendKeys(FindID("userEmail"), "edited@name.exe");
            clearAndSendKeys(FindID("age"), "72");
            clearAndSendKeys(FindID("salary"), "900000");
            clearAndSendKeys(FindID("department"), "Automation Testing");
        }

        private void editEntry()
        {
            click(FindAllBy(By.XPath("//span[@title='Edit']"))[0]);
            wait(100);
            switchToActive();
        }

        private void inputInitialValue()
        {
            sendKeys(FindID("firstName"), "Nameless");
            sendKeys(FindID("lastName"), "Human");
            sendKeys(FindID("userEmail"), "nameless@human.exe");
            sendKeys(FindID("age"), "22");
            sendKeys(FindID("salary"), "9000");
            sendKeys(FindID("department"), "Automation Testing");
        }

        private void searchValues(IWebElement searchBox)
        {
            sendKeys(searchBox, "Cierra");
            wait(500);
            clear(searchBox);
            wait(500);
            sendKeys(searchBox, "45");
            wait(500);
            clear(searchBox);
            wait(500);
            sendKeys(searchBox, "2000");
            wait(500);
            clear(searchBox);
        }
    }
}
