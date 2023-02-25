using SpiderLaiR.Views;
using System.Windows;

namespace SpiderLaiR
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            new LoginView().Show();
            //if (new LoginView().ShowDialog() == true)
            //{
            //    new MainView().ShowDialog();
            //}
            //new MainView().ShowDialog();
            //Application.Current.Shutdown();
        }
    }
}