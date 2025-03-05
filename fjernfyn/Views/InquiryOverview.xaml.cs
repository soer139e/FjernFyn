using fjernfyn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace fjernfyn.Views
{
    /// <summary>
    /// Interaction logic for InquiryOverview.xaml
    /// </summary>
    public partial class InquiryOverview : Page
    {
        public InquiryOverviewViewModel iovm = new InquiryOverviewViewModel();
        public InquiryOverview()
        {
            InitializeComponent();
            DataContext = iovm;

        }

        // metoden fort at åbne en forespørgsel, laves i code behind da der ikke findes en god måde at overholde mvvvm på, så det er ok i  følge en anden gruppe der fik hjælp af leif
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (iovm.SelectedInquiry != null)
            {
                ReadInquiryWindow readWindow = new ReadInquiryWindow(iovm.SelectedInquiry);
                readWindow.Show();
            }
            else
            {
                MessageBox.Show("Ingen Forespørgsel Valgt.","Fejl",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
    }
}
