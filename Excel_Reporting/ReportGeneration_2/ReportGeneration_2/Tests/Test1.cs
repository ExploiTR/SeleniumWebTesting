using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGeneration_2
{
    [TestFixture]
    class Test1 : TestBase
    {
        public Pages Pages;

        [Test]
        public void nopCommerceDummyTest()
        {
            Pages.Home.isAt();

            Pages.Home.goToComputers();

            Pages.Computers.isAt();

            Pages.Computers.EnterSearchText("search for me");
           
            Pages.Computers.clickSearch();
        }
    }
}
