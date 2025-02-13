using System.Windows;
using System.Windows.Controls;

namespace fjernfyn
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class FeedbackCreationWindow : Window
    {
        FeedbackCreateViewModel viewModel = new FeedbackCreateViewModel();

        public FeedbackCreationWindow()
        {
            InitializeComponent();
            DataContext = viewModel;
        }

       

    }
}