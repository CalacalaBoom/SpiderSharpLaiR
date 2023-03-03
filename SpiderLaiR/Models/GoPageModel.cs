using lib;
using SpiderLaiR.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SpiderLaiR.Models
{
    public class GoPageModel:NotifyBase
    {
        private List<string> _sourceList;
        public List<string> sourceList
        {
            get { return _sourceList; }
            set { _sourceList = value; this.DoNotify(); }
        }

        private int _txt_Count=0;
        public int txt_Count
        {
            get { return _txt_Count; }
            set { _txt_Count = value; this.DoNotify(); }
        }

        private string _txt_LastTime;
        public string txt_LastTime
        {
            get { return _txt_LastTime; }
            set { _txt_LastTime = value; this.DoNotify(); }
        }

        private bool _IsbtnEn=true;
        public bool IsbtnEn
        {
            get { return _IsbtnEn; }
            set { _IsbtnEn = value; this.DoNotify(); }
        }

        private int _bar_total = 0;
        public int bar_total
        {
            get { return _bar_total; }
            set { _bar_total = value; this.DoNotify(); }
        }

        private List<TxtModel> _list_Txt;
        public List<TxtModel> list_Txt
        {
            get { return _list_Txt; }
            set { _list_Txt = value; this.DoNotify(); }
        }

        private string _txt_OutInfo;
        public string txt_OutInfo
        {
            get { return _txt_OutInfo; }
            set { _txt_OutInfo = value; this.DoNotify(); }
        }

        public CommandBase event_Start { get;set; }
    }
}
