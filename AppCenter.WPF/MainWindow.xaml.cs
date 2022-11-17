using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppCenter.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            label.Content = "Button Clicked";
        }

        private void BtnLogEvent_Click(object sender, RoutedEventArgs e)
        {
            Analytics.TrackEvent("Button clicked");
            label.Content = "Event Tracked";
        }

        private void BtnLogException_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                throw new Exception();
            }
            catch (Exception exception)
            {
                Crashes.TrackError(exception);
                label.Content = "Exception Logged";
            }
        }

        private void BtnLogExceptionWithInfo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                throw new Exception();
            }
            catch (Exception exception)
            {
                var properties = new Dictionary<string, string>
                                    {
                                        { "Category", "Music" },
                                        { "Wifi", "On"}
                                    };
                Crashes.TrackError(exception, properties);
                label.Content = "Exception Logged with information";
            }
        }

        private void BtnGenerateCrash_Click(object sender, RoutedEventArgs e)
        {
            Crashes.GenerateTestCrash();
        }

        private async void BtnGetCrashAnalysis_Click(object sender, RoutedEventArgs e)
        {
            bool didAppCrash = await Crashes.HasCrashedInLastSessionAsync();
            if (didAppCrash)
            {
                ErrorReport crashReport = await Crashes.GetLastSessionCrashReportAsync();
                label.Content = $"didAppCrash:{didAppCrash}. crashReport:{crashReport.Device.OemName} | {crashReport.StackTrace}"; 
            }
            else
            {
                label.Content = $"App didn't crashed";
            }
        }
    }
}
