using lib;
using Newtonsoft.Json;
using SpiderLaiR.Assets;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SpiderLaiR.Views
{
    /// <summary>
    /// LoginView.xaml 的交互逻辑
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
            Password.Password = "yvon123456";
            //ConfigModel config = new ConfigModel()
            //{
            //    RunStyle = RunStyle.Normal
            //};
            //string json = JsonConvert.SerializeObject(config);
            //var CurrentDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"\\SpiderSharpLaiR";
            //if (!Directory.Exists(CurrentDirectory))
            //{
            //    Directory.CreateDirectory(CurrentDirectory);
            //}
            //StaticCacheMemory.ToWrite(json);
            string configJson = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\SpiderSharpLaiR\\config.ini");
            StaticCacheMemory.config = JsonConvert.DeserializeObject<ConfigModel>(configJson);
        }

        private void eventExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Loading.Visibility = Visibility.Visible;
            if (Password.Password == string.Empty || Password.Password == "")
            {
                Loading.Visibility = Visibility.Hidden;
                return;
            }
            string md5 = SQLHelper.myMD5(Password.Password, 3);
            Task.Run(new Action(() =>
            {
                if (md5 == SQLHelper.Db.Queryable<Userindo>().Single(s => s.Username == "admin").Password)
                {
                    Dispatcher.BeginInvoke(new Action(() =>
                    {
                        Loading.Visibility = Visibility.Hidden;
                        new MainView().Show();
                        this.Close();
                    }));
                }
                else
                {
                    Dispatcher.BeginInvoke(new Action(() =>
                    {
                        Loading.Visibility = Visibility.Hidden;
                        HandyControl.Controls.Growl.Warning("登陆失败");
                    }));
                }
            }));
        }

        private void eventInfo_Click(object sender, RoutedEventArgs e)
        {
            StaticCacheMemory.OpenInBrowser("https://github.com/CalacalaBoom/SpiderSharp");
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            StaticCacheMemory.OpenInBrowser("https://github.com/CalacalaBoom/SpiderSharp");
        }

        private void Au_Click(object sender, RoutedEventArgs e)
        {
            StaticCacheMemory.OpenInBrowser("https://github.com/CalacalaBoom");
        }

        private void HP_Click(object sender, RoutedEventArgs e)
        {
            StaticCacheMemory.OpenInBrowser("https://html-agility-pack.net/");
        }

        private void Watermark_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) this.DragMove();
        }
    }
}