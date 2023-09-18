using System.Windows;
using System.Windows.Controls;
//Namespaces
using wpf_Tricked.ViewModel;

namespace wpf_Tricked.View
{
    public partial class Profiles : UserControl
    {
        ProfilesVM ViewModel = new();

        #region Constructor
        public Profiles()
        {
            InitializeComponent();
        }
        #endregion

        #region TextBox TextChanged Event
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            #region Variables
            int Index = ProfileListBox.SelectedIndex;
            string Name = NameBox?.Text;
            string IngName = IGNBox?.Text;
            string Role = RoleBox?.Text;
            string Elo = EloBox?.Text;
            #endregion

            if (Index != -1)
            {
                SaveBtn.IsEnabled = ViewModel.EnableSave(Index, Name, IngName, Role, Elo);
            }
        }
        #endregion

        #region ProfileListBox SelectionChanged Event
        private void ProfileListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            #region Variables
            int Index = ProfileListBox.SelectedIndex;
            string Name = NameBox?.Text;
            string IngName = IGNBox?.Text;
            string Role = RoleBox?.Text;
            string Elo = EloBox?.Text;
            #endregion

            #region Show/Hide ProfileData
            if (ProfileDataPanel.Visibility == Visibility.Hidden)
            {
                ProfileDataPanel.Visibility = Visibility.Visible;
                ProfileBtnPanel.Visibility = Visibility.Visible;
            }
            #endregion

            if (Index != -1)
            {
                SaveBtn.IsEnabled = ViewModel.EnableSave(Index, Name, IngName, Role, Elo);
            }
        }
        #endregion

        #region Save Click Event
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            #region Variables
            int Index = ProfileListBox.SelectedIndex;
            string Name = NameBox?.Text;
            string IngName = IGNBox?.Text;
            string Role = RoleBox?.Text;
            string Elo = EloBox?.Text;
            #endregion

            ViewModel.Update(Index, Name, IngName, Role, Elo);
            SaveBtn.IsEnabled = false;
            ProfileListBox.ItemsSource = ViewModel.ProfileList;

            #region Clear Selection & Hide ProfileData
            ProfileListBox.UnselectAll();
            ProfileDataPanel.Visibility = Visibility.Hidden;
            ProfileBtnPanel.Visibility = Visibility.Hidden;
            #endregion
        }
        #endregion

        #region Add Click Event
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Add();
            ProfileListBox.ItemsSource = ViewModel.ProfileList;

            #region Set Selection to the newest item
            int Index = ProfileListBox.Items.Count;
            ProfileListBox.SelectedItem = ProfileListBox.Items.GetItemAt(Index-1);
            #endregion
        }
        #endregion

        #region Remove Click Event
        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Remove((Models.Profiles)ProfileListBox.SelectedItem);
            ProfileListBox.ItemsSource = ViewModel.ProfileList;

            #region Clear Selection & Hide ProfileData
            ProfileListBox.UnselectAll();
            ProfileDataPanel.Visibility = Visibility.Hidden;
            ProfileBtnPanel.Visibility = Visibility.Hidden;
            #endregion
        }
        #endregion
    }
}
