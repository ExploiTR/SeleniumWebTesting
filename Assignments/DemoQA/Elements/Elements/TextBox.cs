using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SeleniumBase;

namespace Elements
{
    internal class TextBox : SelActions
    {
        public void run(bool _continue)
        {
            open("https://demoqa.com/text-box");

            wait(500);

            sendKeys(FindID("userName"), "Pratim Majumder");
            sendKeys(FindID("userEmail"), "majumder@gmail.com");
            sendKeys(FindID("currentAddress"), "India");
            sendKeys(FindID("permanentAddress"), "WB, India");

            scrollForElementVisibility(FindID("submit"));

            wait(500);

            click(FindID("submit"));

            wait(3000);

            exit();

            if (_continue)
                new CheckBox().run(_continue);
        }
    }
}
