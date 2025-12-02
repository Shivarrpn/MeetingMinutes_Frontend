using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace MeetingMinutes
{
    /// <summary>
    /// Interaction logic for Meeting.xaml
    /// </summary>
    public partial class Meeting : Window
    {
        private CreateMeetingDto currentMeetingData;
        private List<GetMeetingItemsDto> previousItemsList;
        public Meeting(List<GetMeetingItemsDto> previousItemsList, CreateMeetingDto currentMeetingData)
        {
            InitializeComponent();
            ApiHelper.InitialiseClient();
            this.previousItemsList = previousItemsList;
            this.currentMeetingData = currentMeetingData;

            meetingType_lbl.Content = currentMeetingData.meetingType_meetingType;
            meetingTypeAcronym_lbl.Content = "(" + currentMeetingData.meetingType_typeAcronym + currentMeetingData.meetingNumber + ")";
            meetingDate_lbl.Content = " - " + currentMeetingData.meetingDatetime.ToShortDateString();
        }

        private void add_new_item_btn_Click(object sender, RoutedEventArgs e)
        {
            EditMeetingItem editMeetingItem = new EditMeetingItem();

            new_items_lvw.Items.Add(editMeetingItem);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (previousItemsList != null)
            {
                foreach (var item in previousItemsList)
                {
                    EditMeetingItem meetingItem = new EditMeetingItem();
                    meetingItem.item_txt.Text = item.meetingItem_item;
                    meetingItem.status_cmb.SelectedValue = item.status_status;
                    meetingItem.person_responsible_cmb.SelectedValue = item.person_username;
                    meetingItem.due_date_dp.SelectedDate = item.meetingItem_dueDate;
                    meetingItem.completed_date_dp.SelectedDate = item.meetingItem_completedDate;
                    meetingItem.comment_txt.Text = item.comment;

                    previous_items_lvw.Items.Add(meetingItem);
                }
            }
        }

        private async void end_meeting_btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Please confirm end of meeting", "End Meeting", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                var previousMeetingItems = previous_items_lvw.Items.Cast<GetMeetingItemsDto>().ToList();

                var newMeetingItems = new_items_lvw.Items.Cast<GetMeetingItemsDto>().ToList();

                EndMeetingDto endMeetingDto = new EndMeetingDto(currentMeetingData.id, previousMeetingItems, newMeetingItems);

                await ApiProcessor.EndMeeting(endMeetingDto);

                this.Close();
            }
        }
    }
}
