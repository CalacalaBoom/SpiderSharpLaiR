using SpiderLaiR.ViewModels;
using System.Windows;
using System.Windows.Input;
using Window = System.Windows.Window;

namespace SpiderLaiR.UserControls
{
    /// <summary>
    /// TextDialog.xaml 的交互逻辑
    /// </summary>
    public partial class TextDialog : Window
    {
        public TextDialog(string title, string content)
        {
            InitializeComponent();
            water_Title.Mark = title;
            txt_Title.Text = title;
            txt_Content.Text = content;
        }

        public ExitModel Model { get; set; }

        public TextDialog(ExitModel model)
        {
            InitializeComponent();
            this.Model = model;
            this.DataContext = model;
            water_Title.Mark = "退出";
            txt_Title.Text = "退出";
            txt_Content.Text = "确定退出SpiderSharpLaiR吗？";
            stack_ExitSetting.Visibility = Visibility.Visible;
        }

        private void Watermark_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) this.DragMove();
        }

        private void eventExit_Click(object sender, RoutedEventArgs e)
        {
            Model.isCancel= true;
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}