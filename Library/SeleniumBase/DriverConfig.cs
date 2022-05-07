using OpenQA.Selenium.Chrome;

namespace SeleniumBase
{
    public class DriverConfig
    {
        private ChromeOptions chromeOptions;
        private bool fullScreen = false;
        private bool maximize = false;
        private bool minimize = false;
        private bool hidden = false;

        public bool FullScreen { get => fullScreen; set => fullScreen = value; }
        public bool Maximize { get => maximize; set => maximize = value; }
        public bool Minimize { get => minimize; set => minimize = value; }
        public bool Hidden { get => hidden; set => hidden = value; }
        public ChromeOptions ChromeOptions { get => chromeOptions; set => chromeOptions = value; }

        public static DriverConfig Default()
        {
            var conf = new DriverConfig();
            conf.ChromeOptions = new ChromeOptions();
            conf.FullScreen = false;
            conf.Maximize = true;
            conf.minimize = false;
            conf.Hidden = false;
            return conf;
        }
    }
}
