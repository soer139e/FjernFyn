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
                viewModel.Employee.Password = passwordBox.Password;
            }
        }


        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            /// <summary>
            /// TODO: Implement a timing that waits for the global employee to be set, as right now we dont do anything.
            /// </summary>
            //FeedbackCreationWindow newWindow = new FeedbackCreationWindow();
            this.Visibility = Visibility.Hidden;
            //newWindow.Show(); 
        }
    }
}