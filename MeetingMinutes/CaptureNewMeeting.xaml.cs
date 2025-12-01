using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace MeetingMinutes
{
    /// <summary>
    /// Interaction logic for CaptureNewMeeting.xaml
    /// </summary>
    public partial class CaptureNewMeeting : Window
    {
        private static readonly HttpClient client = new HttpClient();
        public CaptureNewMeeting()
        {
            InitializeComponent();
            ApiHelper.InitialiseClient();
        }

        private async Task LoadMeetingTypeDropdown()
        {
            var meetingType = await MeetingTypeProcessor.LoadMeetingTypes();

            for (int i = 0; i < meetingType.Count; i++)
            {
                meetingType_cmb.Items.Add(meetingType[i].ToString());
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadMeetingTypeDropdown();
        }
    }
}
