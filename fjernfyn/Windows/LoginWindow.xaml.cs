using System.Windows;
using System.Windows.Controls;

namespace fjernfyn
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public LoginViewModel viewModel { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            viewModel = new LoginViewModel(this);
            DataContext = viewModel;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var passwordBox = sender as PasswordBox;
            if (passwordBox != null)
            {
                viewModel.Employee.Password = passwordBox.Password;
            }
        }


      
    }
}