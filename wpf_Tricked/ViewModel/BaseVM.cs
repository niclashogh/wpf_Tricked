using System.ComponentModel;

namespace wpf_Tricked.ViewModel
{
    public class BaseVM : INotifyPropertyChanged
    {
        //EventHandler
        public event PropertyChangedEventHandler PropertyChanged;

        //Method
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
