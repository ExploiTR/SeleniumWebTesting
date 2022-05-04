using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumBase
{
    interface IConditions
    {
        bool isImportantField(IWebElement element);
    }
}
