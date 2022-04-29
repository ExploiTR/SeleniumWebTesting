using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumBase
{
    internal class LinkOptions
    {
        private bool fullScreen;
        private bool maximize;

        public bool FullScreen { get => fullScreen; set => fullScreen = value; }
        public bool Maximize { get => maximize; set => maximize = value; }
    }
}
