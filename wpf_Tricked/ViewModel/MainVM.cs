using System.Windows.Input;
//Namespaces
using wpf_Tricked.ViewModel.Commands;

namespace wpf_Tricked.ViewModel
{
    public class MainVM : BaseVM
    {
        //ContentControl(View) > bound to selVM
        private BaseVM selVM;
        public BaseVM SelVM
        {
            get { return selVM; }
            set { selVM = value; OnPropertyChanged(nameof(SelVM)); }
        }

        //Commands
        public ICommand UpdateViewCMD { get; set; }

        //Constructor
        public MainVM()
        {
            UpdateViewCMD = new NavCommands(this);
        }
    }
}
