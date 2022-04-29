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

namespace Elements
{
    internal class Buttons : SelActions
    {
        public void run(bool _continue)
        {
            open("https://demoqa.com/buttons");

            doubleClick(FindID("doubleClickBtn"));
            contextClick(FindID("rightClickBtn"));
            click(FindXPath("//button[text()='Click Me']"));

            wait(3000);

            exit();

            if (_continue)
                new Links().run(_continue);
        }
    }
}
