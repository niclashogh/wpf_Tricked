using System.Windows.Controls;
//Namespaces
using wpf_Tricked.ViewModel;

namespace wpf_Tricked.View
{
    public partial class Events : UserControl
    {
        EventsVM ViewModel = new();

        #region Constructor
        public Events()
        {
            InitializeComponent();
        }
        #endregion

        #region TextBox TextChanged Event
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            #region Variables
            int Index = EventListBox.SelectedIndex;
            string Location = LocationBox.Text;
            string Date = EventDatePicker.SelectedDate.ToString();
            string Time = $"{HourBox.Text}:{MinBox.Text}";
            #endregion

            if (Index != -1)
            {
                SaveBtn.IsEnabled = ViewModel.EnableSave(Index, Location, Date, Time);
            }
        }
        #endregion

        #region EventListBox SelectionChanged Event
        private void EventListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            #region Variables
            int Index = EventListBox.SelectedIndex;
            string Location = LocationBox.Text;
            string Date = EventDatePicker.SelectedDate.ToString();
            string Time = $"{HourBox.Text}:{MinBox.Text}";
            #endregion

            if (Index != -1)
            {
                SaveBtn.IsEnabled = ViewModel.EnableSave(Index, Location, Date, Time);
            }
        }
        #endregion

        #region EventDatePicker SelectedDateChanged Event
        private void EventDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            #region Variables
            int Index = EventListBox.SelectedIndex;
            string Location = LocationBox.Text;
            string Date = EventDatePicker.SelectedDate.ToString();
            string Time = $"{HourBox.Text}:{MinBox.Text}";
            #endregion

            if (Index != -1)
            {
                SaveBtn.IsEnabled = ViewModel.EnableSave(Index, Location, Date, Time);
            }
        }
        #endregion

    }
}
