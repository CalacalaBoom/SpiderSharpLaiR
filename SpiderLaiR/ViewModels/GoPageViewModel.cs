using Masuit.Tools;
using Newtonsoft.Json;
using SpiderLaiR.Assets;
using SpiderLaiR.Common;
using SpiderLaiR.Models;
using SpiderLaiR.UserControls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpiderLaiR.ViewModels
{
    public class GoPageViewModel
    {
        public GoPageModel Model { get; set; }=new GoPageModel();

        public GoPageViewModel()
        {
            Model.sourceList = new List<string> { "新笔趣阁（http://www.vbiquge.co/）"};
            string configJson = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\SpiderSharpLaiR\\config.ini");
            StaticCacheMemory.config = JsonConvert.DeserializeObject<ConfigModel>(configJson);
            Model.txt_Count = StaticCacheMemory.config.Count;
            Model.txt_LastTime=StaticCacheMemory.config.LastTime.IsNullOrEmpty()?"没有爬过":StaticCacheMemory.config.LastTime;
            Model.event_Start = new CommandBase();
            Model.event_Start.DoExcute = new Action<object>(OnStart);
            Model.event_Start.DoCanExcute=new Func<object, bool>((o) => { return true; });
        }

        private void OnStart(object obj)
        {
            new Thread(() =>
            {
                
            }).Start();
        }
    }
}
