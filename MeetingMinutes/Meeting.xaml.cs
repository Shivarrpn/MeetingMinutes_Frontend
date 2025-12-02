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
        private List<GetMeetingItemsDto> previousItemsList;
        public Meeting(List<GetMeetingItemsDto> previousItemsList)
        {
            InitializeComponent();
            this.previousItemsList = previousItemsList;
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
    }
}
