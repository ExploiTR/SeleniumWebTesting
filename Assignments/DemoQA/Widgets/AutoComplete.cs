using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumBase;

namespace Widgets
{
    internal class AutoComplete : SelActions
    {

        public void start(bool chain)
        {
            open("https://demoqa.com/auto-complete");

            testMultiColorName();
            testSingleColorName();

            exit();

            if (chain)
            {
                new DatePickerInput().start(chain);
            }
        }

        private void testSingleColorName()
        {
            var mu_in = FindID("autoCompleteSingleInput");

            mu_in.SendKeys("Gree");
            wait(1000);
            mu_in.SendKeys(Keys.Enter);
        }

        private void testMultiColorName()
        {
            var mu_in = FindID("autoCompleteMultipleInput");

            mu_in.SendKeys("Gree");
            wait(1000);
            mu_in.SendKeys(Keys.Enter);

            mu_in.SendKeys("Bl");
            wait(500);
            mu_in.SendKeys(Keys.ArrowDown);
            wait(1000);
            mu_in.SendKeys(Keys.Enter);
        }
    }
}
