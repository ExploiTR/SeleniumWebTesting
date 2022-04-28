using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumBase
{
    internal class Test : SelActions
    {
        public static void Main(String[] args)
        {
            new Test().start();
        }

        private void start()
        {
            var linkOpt = new LinkOptions();
            linkOpt.Maximize = true;
            linkOpt.FullScreen = false;
            open("https://www.google.com",linkOpt);
            sendKeys(findElementXPath("//input[@title='Search']"),"mango");
            click(findElementXPath("//input[@value='Google Search']"));
        }
    }
}
