using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elements
{
    internal class Runner
    {

        //only uncomment single class
        public static void Main(string[] args)
        {

            bool continueChain = true;

            new TextBox().run(continueChain); //chain starter
            //new CheckBox().run(continueChain);
            //new RadioButton().run(continueChain);
            //new WebTables().run(continueChain);
            //new Buttons().run(continueChain);
            //new Links().run(continueChain);
            //new BrokenLink().run(continueChain);
            //new UploadAndDownload().run(continueChain);
            //new DynamicProps().run();

            return;
        }
    }
}
