using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using SeleniumBase;

namespace Elements
{
    internal class Links : SelActions
    {
        public void run(bool _continue)
        {

            open("https://demoqa.com/links");
            click(FindID("simpleLink"));
            wait(500);
            switchToWindow(1);
            wait(500);
            close();

            switchToWindow(0);
            click(FindID("dynamicLink"));
            wait(500);
            switchToWindow(1);
            wait(500);
            close();

            switchToWindow(0);

            click(FindID("created"));
            click(FindID("no-content"));
            click(FindID("moved"));
            click(FindID("bad-request"));
            click(FindID("unauthorized"));
            click(FindID("forbidden"));
            click(FindID("invalid-url"));

            wait(3000);
            exit();

            if (_continue)
            {
                new BrokenLink().run(_continue);
            }
        }
    }
}
