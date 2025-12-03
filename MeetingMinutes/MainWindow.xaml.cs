using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace MeetingMinutes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ApiHelper.InitialiseClient();
        }

        private async Task LoadReportSelectionDropdown()
        {
            List<string> reportTypes = new List<string>();

            reportTypes.Add("Item History");
            reportTypes.Add("Items by Meeting Type");
            reportTypes.Add("Items by Meeting Type & Meeting Number");
            reportTypes.Add("Items Per Person");

            for (int i = 0; i < reportTypes.Count; i++)
            {
                report_cmb.Items.Add(reportTypes[i].ToString());
            }
        }

        private void captureNewMeeting_btn_Click(object sender, RoutedEventArgs e)
        {
            CaptureNewMeeting captureNewMeeting = new CaptureNewMeeting();

            captureNewMeeting.ShowDialog();
        }

        private async void report_cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var testString = await ApiProcessor.TestApi();

            apiConnected_lbl.Foreground = new SolidColorBrush(Colors.Green);
            apiConnected_lbl.Content = testString;
            await LoadReportSelectionDropdown();
        }
    }
}
