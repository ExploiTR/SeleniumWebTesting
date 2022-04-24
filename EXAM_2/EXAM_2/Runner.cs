using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAM_2
{
    internal class Runner
    {
        static void Main(string[] args)
        {
            new Registration().start(false);
          //  new MouseEvent().start(false);
        }
    }
}
