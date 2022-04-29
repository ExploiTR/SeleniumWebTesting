using SeleniumBase;

namespace AlertFrameWindows
{
    internal class NestedFrames : SelActions
    {
        public void start(bool chain)
        {
            open("https://demoqa.com/nestedframes");

            exit();

            if (chain)
            {
                new Modal().start(chain);
            }

        }
    }
}
