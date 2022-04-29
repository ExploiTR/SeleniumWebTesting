using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using SeleniumBase;

namespace Elements
{
    internal class CheckBox : SelActions
    {
        public void run(bool _continue)
        {

            open("https://demoqa.com/checkbox");

            wait(500);
            click(FindXPath("//button[@title='Expand all']"));//expand root
            wait(500);
            click(FindXPath("//button[@title='Collapse all']")); //collapse root

            wait(500);
            toggleHome();
            wait(500);
            toggleDesktop();
            wait(500);
            toggleNotes();
            wait(500);
            toggleDocuments();
            wait(500);
            toggleWorkSpace();
            wait(500);
            toggleAngularTab();
            wait(500);
            toggleAngularTab();
            wait(500);
            toggleWorkSpace();
            wait(500);
            toggleDocuments();
            wait(500);
            toggleDesktop();
            wait(500);
            toggleHome();

            wait(2000);
            exit();

            if (_continue)
                new RadioButton().run(_continue);
        }

        private void toggleHome()
        {
            click(FindXPath("//span[text()='Home']"));
            click(FindAllBy(By.XPath("//button[@title='Toggle']"))[0]);
        }

        private void toggleNotes()
        {
            click(FindXPath("//span[text()='Notes']"));
        }

        private void toggleDocuments()
        {
            click(FindXPath("//span[text()='Documents']"));
            click(FindAllBy(By.XPath("//button[@title='Toggle']"))[2]);
        }

        private void toggleDesktop()
        {
            click(FindXPath("//span[text()='Desktop']"));
            click(FindAllBy(By.XPath("//button[@title='Toggle']"))[1]);
        }

        private void toggleAngularTab()
        {
            click(FindXPath("//span[text()='Angular']"));
        }

        private void toggleWorkSpace()
        {
            click(FindXPath("//span[text()='WorkSpace']"));
            click(FindAllBy(By.XPath("//button[@title='Toggle']"))[3]);
        }
    }
}

