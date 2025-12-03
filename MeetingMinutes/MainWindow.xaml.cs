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
        private bool isChangingSelection = false;
        public MainWindow()
        {
            InitializeComponent();
            ApiHelper.InitialiseClient();

            meetingItem_lbl.Visibility = Visibility.Collapsed;
            meetingItem_txt.Visibility = Visibility.Collapsed;

            meetingType_lbl.Visibility = Visibility.Collapsed;
            meetingType_cmb.Visibility = Visibility.Collapsed;

            meetingNumber_lbl.Visibility = Visibility.Collapsed;
            meetingNumber_cmb.Visibility = Visibility.Collapsed;

            search_Button.Visibility = Visibility.Collapsed;
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
            report_lvw.Items.Clear();
            string selectedReport = report_cmb.SelectedValue.ToString();

            meetingItem_txt.Text = "";
            meetingType_cmb.Items.Clear();
            meetingNumber_cmb.Items.Clear();

            if (selectedReport == "Item History")
            {
                meetingItem_lbl.Visibility = Visibility.Visible;
                meetingItem_txt.Visibility = Visibility.Visible;

                meetingType_lbl.Visibility = Visibility.Collapsed;
                meetingType_cmb.Visibility = Visibility.Collapsed;

                meetingNumber_lbl.Visibility = Visibility.Collapsed;
                meetingNumber_cmb.Visibility = Visibility.Collapsed;
                search_Button.Visibility = Visibility.Visible;
                search_Button.IsEnabled = true;

                var itemHistory = await ApiProcessor.GetReportData(selectedReport, "", "", 0);

                foreach ( var item in itemHistory )
                {
                    report_lvw.Items.Add(item);
                }
            }
            else if (selectedReport == "Items by Meeting Type")
            {
                meetingItem_lbl.Visibility = Visibility.Collapsed;
                meetingItem_txt.Visibility = Visibility.Collapsed;

                meetingType_lbl.Visibility = Visibility.Visible;
                meetingType_cmb.Visibility = Visibility.Visible;

                meetingNumber_lbl.Visibility = Visibility.Collapsed;
                meetingNumber_cmb.Visibility = Visibility.Collapsed;
                search_Button.Visibility = Visibility.Visible;
                search_Button.IsEnabled = false;

                var meetingTypes = await ApiProcessor.LoadMeetingTypes();

                foreach (var meetingType in meetingTypes)
                {
                    meetingType_cmb.Items.Add(meetingType);
                }
            }
            else if (selectedReport == "Items by Meeting Type & Meeting Number")
            {
                meetingItem_lbl.Visibility = Visibility.Collapsed;
                meetingItem_txt.Visibility = Visibility.Collapsed;

                meetingType_lbl.Visibility = Visibility.Visible;
                meetingType_cmb.Visibility = Visibility.Visible;

                meetingNumber_lbl.Visibility = Visibility.Visible;
                meetingNumber_cmb.Visibility = Visibility.Visible;
                search_Button.Visibility = Visibility.Visible;
                meetingNumber_cmb.IsEnabled = false;

                var meetingTypes = await ApiProcessor.LoadMeetingTypes();

                foreach ( var meetingType in meetingTypes )
                {
                    meetingType_cmb.Items.Add(meetingType);
                }
            }
            else if (selectedReport == "Items Per Person")
            {
                report_lvw.Items.Clear();
                meetingItem_lbl.Visibility = Visibility.Collapsed;
                meetingItem_txt.Visibility = Visibility.Collapsed;

                meetingType_lbl.Visibility = Visibility.Collapsed;
                meetingType_cmb.Visibility = Visibility.Collapsed;

                meetingNumber_lbl.Visibility = Visibility.Collapsed;
                meetingNumber_cmb.Visibility = Visibility.Collapsed;

                search_Button.Visibility = Visibility.Collapsed;

                var reportData = await ApiProcessor.GetReportData(selectedReport, "", "", 0);
                    foreach (var item in reportData)
                    {
                        report_lvw.Items.Add(item);
                    }
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var testString = await ApiProcessor.TestApi();

            apiConnected_lbl.Foreground = new SolidColorBrush(Colors.Green);
            apiConnected_lbl.Content = testString;
            await LoadReportSelectionDropdown();
        }

        private async void search_Button_Click(object sender, RoutedEventArgs e)
        {
            report_lvw.Items.Clear();
            string selectedReport = report_cmb.SelectedValue.ToString();
            if (selectedReport == "Item History" && meetingItem_txt != null)
            {
                var reportData = await ApiProcessor.GetReportData(selectedReport, meetingItem_txt.Text.ToString(), "", 0);

                foreach (var item in reportData)
                {
                    report_lvw.Items.Add(item);
                }
            }
            else if (selectedReport == "Items by Meeting Type" && meetingType_cmb.SelectedValue.ToString() != null)
            {
                var reportData = await ApiProcessor.GetReportData(selectedReport, "", meetingType_cmb.SelectedValue.ToString(), 0);

                foreach (var item in reportData)
                {
                    report_lvw.Items.Add(item);
                }
            }
            else if (selectedReport == "Items by Meeting Type & Meeting Number" && meetingType_cmb.SelectedValue.ToString() != null && meetingNumber_cmb.SelectedValue.ToString() != null)
            {
                var reportData = await ApiProcessor.GetReportData(selectedReport, "", meetingType_cmb.SelectedValue.ToString(), int.Parse(meetingNumber_cmb.SelectedValue.ToString()));

                foreach (var item in reportData)
                {
                    report_lvw.Items.Add(item);
                }
            }
            else
            {

            }
        }

        private async void meetingType_cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            isChangingSelection = true;
            meetingNumber_cmb.Items.Clear();
            isChangingSelection = false;
            string selectedReport = report_cmb.SelectedValue.ToString();
            if (selectedReport == "Items by Meeting Type" && meetingType_cmb.SelectedValue != null)
            {
                search_Button.IsEnabled = true;
            }
            else if (selectedReport == "Items by Meeting Type & Meeting Number" && meetingType_cmb.SelectedValue != null)
            {
                meetingNumber_cmb.Items.Clear();
                meetingNumber_cmb.IsEnabled = true;

                var meetingNumbers = await ApiProcessor.LoadMeetingNumbersByMeetingType(meetingType_cmb.SelectedValue.ToString());

                foreach (var meetingNumber in meetingNumbers)
                {
                    meetingNumber_cmb.Items.Add(meetingNumber);
                }
                search_Button.IsEnabled = false;
            }
            else
            {
                meetingNumber_cmb.IsEnabled = true;
                search_Button.IsEnabled = false;
            }
        }

        private async void meetingNumber_cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isChangingSelection) return;
            string selectedReport = report_cmb.SelectedValue.ToString();
            if(selectedReport == "Items by Meeting Type & Meeting Number" && meetingType_cmb.SelectedValue.ToString() != null && meetingNumber_cmb.SelectedValue.ToString() != null)
            {
                search_Button.IsEnabled = true;
            }
            else
            {
                search_Button.IsEnabled = false;
            }
        }
    }
}
