using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Drawing;
using OpenQA.Selenium.Interactions;
using System.Threading;
using System;
using SharpAvi;
using SharpAvi.Output;
using SharpAvi.Codecs;
using System.Diagnostics;

namespace Samples
{
    internal class Program
    {
        //https://trac.ffmpeg.org/wiki/Capture/Desktop
        //ffmpeg -f gdigrab -framerate 30 -i desktop -c:v h264_nvenc -qp 0 output.mkv

        private static AviWriter writer;
        private static bool putFrames = false;
        private static Process process;

        static void Main(string[] args)
        {
            startRecordingFFMpeg();
            runTest();
            stopRecordingFFMpeg();
        }

        private static void stopRecordingFFMpeg()
        {
            var standardInput = process.StandardInput;
            standardInput.AutoFlush = true;
            standardInput.WriteLine("q");
            standardInput.Close(); 
        }

        private static void startRecordingFFMpeg()
        {
            process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.RedirectStandardInput = true;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/k ffmpeg -f gdigrab -framerate 60 -i desktop -c:v h264_nvenc -qp 0 C:\\Users\\ExploiTR\\Desktop\\output.mkv";
            startInfo.UseShellExecute = false;
            process.StartInfo = startInfo;
            process.Start();
        }

        //unused
        private static void stopRecording()
        {
            putFrames = false;
            writer.Close();
        }

        //unused
        private static void startRecording()
        {
            new Thread(() =>
            {
                writer = new AviWriter("C:\\Users\\ExploiTR\\Desktop\\test.avi")
                {
                    FramesPerSecond = 60,
                    EmitIndex1 = true
                };

                var stream = writer.AddVideoStream();
                stream.Width = 1920;
                stream.Height = 1080;
                stream.Codec = CodecIds.Uncompressed;
                stream.BitsPerPixel = BitsPerPixel.Bpp32;
                putFrames = true;

                var frameData = new byte[stream.Width * stream.Height * 4];
                while (putFrames)
                {

                    stream.WriteFrame(true,
                                      frameData,
                                      0,
                                      frameData.Length
                    );
                }
            }).Start();
            //.NET 5.0+ stream.WriteFrame(true, frameData.AsSpan());
        }

        static void runTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.toolsqa.com/");

            var b1 = driver.FindElement(By.XPath("//span[text()='Tutorials']"));
            b1.Click();
            driver.SwitchTo().ActiveElement();

            new Actions(driver).
                MoveToElement(driver.FindElement(By.XPath("//span[text()='Front-End Testing Automation']")))
                .Build()
                .Perform();

            var element = driver.FindElement(By.XPath("//div[@class='col-4']//a[text()='Selenium C Sharp']"));

            Screenshot sc = ((ITakesScreenshot)driver).GetScreenshot();
            sc.SaveAsFile("C:\\Users\\ExploiTR\\Desktop\\test.png");

            Image img = Bitmap.FromFile("C:\\Users\\ExploiTR\\Desktop\\test.png");
            Rectangle rect = new Rectangle();

            if (element != null)
            {
                int width = element.Size.Width;
                int height = element.Size.Height;

                Point p = element.Location;

                rect = new Rectangle(p.X, p.Y, width, height);

                Bitmap bmp = new Bitmap(img);
                var cropedImage = bmp.Clone(rect, bmp.PixelFormat);

                cropedImage.Save("C:\\Users\\ExploiTR\\Desktop\\cropped.png");
            }

            Thread.Sleep(5000);
            driver.Quit();
        }
    }

}
