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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MeetingMinutes
{
    /// <summary>
    /// Interaction logic for editMeetingItem.xaml
    /// </summary>
    public partial class EditMeetingItem : UserControl
    {
        public EditMeetingItem()
        {
            InitializeComponent();
        }

        private void due_date_dp_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (due_date_dp.SelectedDate < System.DateTime.Today)
            {
                MessageBox.Show("You cannot select any date before the current date", "Invalid Date Selected", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                due_date_dp.SelectedDate = System.DateTime.Today;
            }
        }
    }
}
