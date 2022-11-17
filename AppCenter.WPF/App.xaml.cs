using System.Windows;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace AppCenter.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Microsoft.AppCenter.AppCenter.Start(
                appSecret: "f85990b6-6d4d-4789-b8b1-1aa62e98d8a0",
                typeof(Analytics),
                typeof(Crashes));
        }
    }
}
