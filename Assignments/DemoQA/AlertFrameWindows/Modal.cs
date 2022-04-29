using OpenQA.Selenium;
using SeleniumBase;
using System.Threading;

namespace AlertFrameWindows
{
    internal class Modal : SelActions
    {
        public void start(bool chain)
        {
            open("https://demoqa.com/modal-dialogs");

            interactWithSmallModal();
            interactWithLargeModal();

            exit();
        }

        private void interactWithLargeModal()
        {
            FindID("showLargeModal").Click();
            wait(1000);
            switchToActive();
            FindID("closeLargeModal").Click();
            switchToDefault();
        }

        private void interactWithSmallModal()
        {
            FindID("showSmallModal").Click();
            wait(1000);
            switchToActive();
            FindID("closeSmallModal").Click();
            switchToDefault();
        }
    }
}
