using HandyControl.Controls;
using Newtonsoft.Json;
using SpiderLaiR.Assets;
using SpiderLaiR.Common;
using SpiderLaiR.Models;
using SpiderLaiR.UserControls;
using SpiderLaiR.Views;
using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Media.Imaging;

namespace SpiderLaiR.ViewModels
{
    internal class MainViewModel : NotifyBase
    {
        public MainModel model_Main { get; set; }
        public CommandBase com_CloseWindow { get; set; }
        public CommandBase NavChangedCommand { get; set; }
        public MainView MainView { get; set; }

        public MainViewModel(MainView mainview)
        {
            model_Main=new MainModel();
            this.MainView = mainview;
            com_CloseWindow = new CommandBase();
            com_CloseWindow.DoExcute = new Action<object>(DoClose);
            com_CloseWindow.DoCanExcute = new Func<object, bool>((o) => { return true; });
            this.NavChangedCommand = new CommandBase();
            this.NavChangedCommand.DoExcute = new Action<object>(DoNavChanged);
            this.NavChangedCommand.DoCanExcute = new Func<object, bool>((o) => true);
            DoNavChanged("GoPageView");
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
            model.isCancel= false;
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
    }

    public class ExitModel
    {
        public bool isExit { get; set; }
        public bool isTray { get; set; }
        public bool isChecked { get; set; }
        public bool isCancel { get; set; }
    }
}