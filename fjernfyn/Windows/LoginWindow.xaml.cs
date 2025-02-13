using System.Windows;
using System.Windows.Controls;

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

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var passwordBox = sender as PasswordBox;
            if (passwordBox != null)
            {
                var viewModel = (LoginViewModel)this.DataContext;
                viewModel.Password = passwordBox.Password;
            }
        }

    }
}