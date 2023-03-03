using HandyControl.Controls;
using Masuit.Tools.Hardware;
using Newtonsoft.Json;
using SpiderLaiR.Assets;
using SpiderLaiR.Common;
using SpiderLaiR.Models;
using SpiderLaiR.UserControls;
using SpiderLaiR.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace SpiderLaiR.ViewModels
{
    internal class MainViewModel : NotifyBase, IDisposable
    {
        public MainModel model_Main { get; set; }
        public CommandBase com_CloseWindow { get; set; }
        public CommandBase NavChangedCommand { get; set; }
        public MainView MainView { get; set; }
        bool taskSwitch = true;
        List<Task> tasks = new List<Task>();

        public MainViewModel(MainView mainview)
        {
            model_Main = new MainModel();
            this.MainView = mainview;
            com_CloseWindow = new CommandBase();
            com_CloseWindow.DoExcute = new Action<object>(DoClose);
            com_CloseWindow.DoCanExcute = new Func<object, bool>((o) => { return true; });
            this.NavChangedCommand = new CommandBase();
            this.NavChangedCommand.DoExcute = new Action<object>(DoNavChanged);
            this.NavChangedCommand.DoCanExcute = new Func<object, bool>((o) => true);
            for (int i = 0; i < 100; i++)
            {
                model_Main.cvLoad.Add(0);
                model_Main.cvTemperature.Add(0);
                model_Main.cvMemoryAvailable.Add(0);
                model_Main.cvDisk.Add(0);
            }
            this.RefreshValue();
            DoNavChanged("GoPageView");
        }

        private void RefreshValue()
        {
            var task = Task.Factory.StartNew(new Action(async () =>
            {
                while (taskSwitch)
                {
                    float load = SystemInfo.CpuLoad;
                    model_Main.maxLoad = load > model_Main.maxLoad ? load : model_Main.maxLoad;
                    float temper = SystemInfo.GetNetData(NetData.ReceivedAndSent);
                    model_Main.maxTemperature = temper > model_Main.maxTemperature ? temper : model_Main.maxTemperature;
                    float mem = SystemInfo.GetUsageVirtualMemory();
                    model_Main.maxMemoryAvailable = mem > model_Main.maxMemoryAvailable ? mem : model_Main.maxMemoryAvailable;
                    float disk = SystemInfo.GetDiskData(DiskData.ReadAndWrite) / 1024;
                    model_Main.maxDisk = disk > model_Main.maxDisk ? disk : model_Main.maxDisk;

                    if (model_Main.cvLoad.Count > 100) model_Main.cvLoad.RemoveAt(0);
                    model_Main.cvLoad.Add(load);
                    model_Main.Load = ((int)load).ToString() + "%";

                    if (model_Main.cvTemperature.Count > 100) model_Main.cvTemperature.RemoveAt(0);
                    model_Main.cvTemperature.Add(temper);
                    model_Main.Temperature = (Math.Round((temper / 1024), 2)).ToString() + "KB/s";

                    if (model_Main.cvMemoryAvailable.Count > 100) model_Main.cvMemoryAvailable.RemoveAt(0);
                    model_Main.cvMemoryAvailable.Add(mem);
                    model_Main.MemoryAvailable = ((int)mem).ToString() + "%";

                    if (model_Main.cvDisk.Count > 100) model_Main.cvDisk.RemoveAt(0);
                    model_Main.cvDisk.Add(disk);
                    model_Main.Disk = ((int)disk).ToString() + "KB/s";

                    await Task.Delay(5000);
                }
            }));
            tasks.Add(task);
        }

        private void DoNavChanged(object obj)
        {
            Type type = Type.GetType("SpiderLaiR.Views." + obj.ToString());
            ConstructorInfo cti = type.GetConstructor(System.Type.EmptyTypes);
            this.model_Main.MainContent = (FrameworkElement)cti.Invoke(null);
        }

        private NotifyIcon _notifyIcon;

        private void DoClose(object obj)
        {
            ExitModel model = new ExitModel()
            {
                isChecked = StaticCacheMemory.config.IsChecked
            };
            if (StaticCacheMemory.config.IsChecked)
            {
                model.isExit = StaticCacheMemory.config.RunStyle == RunStyle.Normal ? true : false;
                model.isTray = StaticCacheMemory.config.RunStyle == RunStyle.Tray ? true : false;
            }
            else
            {
                model.isExit = true;
                model.isTray = false;
            }
            model.isCancel = false;
            new TextDialog(model).ShowDialog();
            if (model.isCancel) return;
            var CurrentDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\SpiderSharpLaiR";
            if (!Directory.Exists(CurrentDirectory))
            {
                Directory.CreateDirectory(CurrentDirectory);
            }

            if (model.isExit)
            {
                ConfigModel config = new ConfigModel()
                {
                    RunStyle = RunStyle.Normal,
                    IsChecked = model.isChecked
                };
                string json = JsonConvert.SerializeObject(config);
                StaticCacheMemory.ToWrite(json);
                MainView.Close();
            }
            else
            {
                ConfigModel config = new ConfigModel()
                {
                    RunStyle = RunStyle.Tray,
                    IsChecked = model.isChecked
                };
                string json = JsonConvert.SerializeObject(config);
                StaticCacheMemory.ToWrite(json);
                string configJson = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\SpiderSharpLaiR\\config.ini");
                StaticCacheMemory.config = JsonConvert.DeserializeObject<ConfigModel>(configJson);
                InitialTray();
            }
        }

        private void InitialTray()
        {
            MainView.Visibility = System.Windows.Visibility.Hidden;
            _notifyIcon = new NotifyIcon();
            _notifyIcon.Text = "SpiderSharpLaiR";
            _notifyIcon.Icon = new BitmapImage(new Uri("Logo.png", UriKind.Relative));
            _notifyIcon.MouseDoubleClick += _notifyIcon_MouseDoubleClick;
            _notifyIcon.Init();
        }

        private void _notifyIcon_MouseDoubleClick(object sender, System.Windows.RoutedEventArgs e)
        {
            if (MainView.Visibility == Visibility.Visible)
            {
                MainView.Visibility = Visibility.Hidden;
            }
            else
            {
                MainView.Visibility = Visibility.Visible;
                MainView.Activate();
            }
        }

        public void Dispose()
        {
            taskSwitch = false;
            try
            {
                Task.WaitAll(this.tasks.ToArray());
            }
            catch (Exception) { }
        }
    }

    public class ExitModel
    {
        public bool isExit { get; set; }
        public bool isTray { get; set; }
        public bool isChecked { get; set; }
        public bool isCancel { get; set; }
    }
}