using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAY2Automation
{
    internal class Runner
    {
        static void Main(string[] args)
        {
            bool chainTest = false;
          //  new Registration().start(chainTest);
            new Draggable().start(chainTest);
        }
    }
}
