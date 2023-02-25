using SpiderLaiR.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SpiderLaiR.Models
{
    class MainModel: NotifyBase
    {
        private FrameworkElement _maincontent;

        public FrameworkElement MainContent
        {
            get { return _maincontent; }
            set { _maincontent = value; this.DoNotify(); }
        }
    }
}
