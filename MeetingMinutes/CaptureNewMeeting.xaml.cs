using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace MeetingMinutes
{
    /// <summary>
    /// Interaction logic for CaptureNewMeeting.xaml
    /// </summary>
    public partial class CaptureNewMeeting : Window
    {
        private static readonly HttpClient client = new HttpClient();
        private string meetingTypeSelection;
        private bool isChangingSelection = false;
        private bool isClosingWindow = false;
        public CaptureNewMeeting()
        {
            InitializeComponent();
            ApiHelper.InitialiseClient();

            for (int i = 0; i < 24; i++)
            {
                meetingTimeHour_cmb.Items.Add(i);
            }
            for (int i = 0; i < 60; i++)
            {
                meetingTimeMinute_cmb.Items.Add(i);
            }
        }

        private async Task LoadMeetingTypeDropdown()
        {
            var meetingType = await ApiProcessor.LoadMeetingTypes();

            for (int i = 0; i < meetingType.Count; i++)
            {
                meetingType_cmb.Items.Add(meetingType[i].ToString());
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadMeetingTypeDropdown();
        }

        private async void meetingType_cmb_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (isChangingSelection) return;

                if (previousMeetingItemsToForward_lvw.Items.Count > 0)
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure you wish to change meeting type?\n\nPlease note that by selecting yes, all items selected to load into meeting will be cleared", "Please Confirm Change", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                    {
                        previousMeetingItems_lvw.Items.Clear();
                        previousMeetingItemsToForward_lvw.Items.Clear();

                        var previousMeetingItems = await ApiProcessor.GetPreviousMeetingItems(meetingType_cmb.SelectedValue.ToString());
                        foreach (var item in previousMeetingItems)
                        {
                            previousMeetingItems_lvw.Items.Add(item);
                        }
                    }
                    else if (result == MessageBoxResult.No)
                    {
                        isChangingSelection = true;
                        meetingType_cmb.SelectedItem = meetingTypeSelection;
                        isChangingSelection = false;
                    }
                }
                else
                {
                    previousMeetingItems_lvw.Items.Clear();
                    previousMeetingItemsToForward_lvw.Items.Clear();

                    var previousMeetingItems = await ApiProcessor.GetPreviousMeetingItems(meetingType_cmb.SelectedValue.ToString());
                    foreach (var item in previousMeetingItems)
                    {
                        previousMeetingItems_lvw.Items.Add(item);
                    }
                    meetingTypeSelection = meetingType_cmb.SelectedValue.ToString();
                }
        }

        private void forward_btn_Click(object sender, RoutedEventArgs e)
        {
            var selectedItemsToMove = previousMeetingItems_lvw.SelectedItems.Cast<GetMeetingItemsDto>().ToList();

            foreach (var selectedItem in selectedItemsToMove)
            {
                previousMeetingItemsToForward_lvw.Items.Add(selectedItem);
                previousMeetingItems_lvw.Items.Remove(selectedItem);
                previousMeetingItems_lvw.Items.SortDescriptions.Add(new SortDescription("meetingItem_id", ListSortDirection.Ascending));
                previousMeetingItemsToForward_lvw.Items.SortDescriptions.Add(new SortDescription("meetingItem_id", ListSortDirection.Ascending));
            }
        }

        private void return_btn_Click(object sender, RoutedEventArgs e)
        {
            var selectedItemsToMove = previousMeetingItemsToForward_lvw.SelectedItems.Cast<GetMeetingItemsDto>().ToList();

            foreach (var selectedItem in selectedItemsToMove)
            {
                previousMeetingItems_lvw.Items.Add(selectedItem);
                previousMeetingItemsToForward_lvw.Items.Remove(selectedItem);
                previousMeetingItems_lvw.Items.SortDescriptions.Add(new SortDescription("meetingItem_id", ListSortDirection.Ascending));
                previousMeetingItemsToForward_lvw.Items.SortDescriptions.Add(new SortDescription("meetingItem_id", ListSortDirection.Ascending));
            }
        }

        private void meetingDate_dp_SelectedDateChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (meetingDate_dp.SelectedDate < System.DateTime.Today)
            {
                MessageBox.Show("You cannot select any date before the current date", "Invalid Date Selected", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                meetingDate_dp.SelectedDate = System.DateTime.Today;
            }
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (isClosingWindow) return;

            MessageBoxResult result = MessageBox.Show("Are you sure you want to cancel?", "Confirm Meeting Cancellation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        private async void createMeeting_btn_Click(object sender, RoutedEventArgs e)
        {
            if (meetingType_cmb.SelectedItem != null && meetingDate_dp.SelectedDate != null && meetingTimeHour_cmb.SelectedValue != null && meetingTimeMinute_cmb.SelectedValue != null)
            {
                List<GetMeetingItemsDto> previousItemsToForwardList = new List<GetMeetingItemsDto>();

                DateTime? selectedDate = meetingDate_dp.SelectedDate;
                int hour = int.Parse(meetingTimeHour_cmb.SelectedValue.ToString());
                int minute = int.Parse(meetingTimeMinute_cmb.SelectedValue.ToString());

                DateTime meetingDateTime = new DateTime(
                    selectedDate.Value.Year,
                    selectedDate.Value.Month,
                    selectedDate.Value.Day,
                    hour, minute,
                    0);

                var newMeeting = await ApiProcessor.CreateMeeting(meetingType_cmb.SelectedValue.ToString(), meetingDateTime);

                foreach (GetMeetingItemsDto item in previousMeetingItemsToForward_lvw.Items)
                {
                    previousItemsToForwardList.Add(item);
                }

                Window meeting = new Meeting(previousItemsToForwardList, newMeeting);
                meeting.Show();
                isClosingWindow = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please fill in all required fields!", "Missing Input", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}