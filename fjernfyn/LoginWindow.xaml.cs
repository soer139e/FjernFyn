using System.Windows;

namespace fjernfyn
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LoginViewModel viewModel = new LoginViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}