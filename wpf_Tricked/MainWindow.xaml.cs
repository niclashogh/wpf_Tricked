using System.Windows;
using wpf_Tricked.ViewModel;

namespace wpf_Tricked
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainVM();
        }
    }
}
