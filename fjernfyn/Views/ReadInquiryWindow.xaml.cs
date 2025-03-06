using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;
using fjernfyn.Classes;
using fjernfyn.ViewModels;


namespace fjernfyn.Views
{
    /// <summary>
    /// Interaction logic for ReadInquiryWindow.xaml
    /// </summary>
    public partial class ReadInquiryWindow : Window
    {
      
        public ReadInquiryViewModel RIVM { get; set; }
        public Feedback Inquiry { get; set; }
        public ReadInquiryWindow(Feedback inquiry)
        {
            InitializeComponent();
                Inquiry = inquiry;
            RIVM = new ReadInquiryViewModel(inquiry);
            DataContext = RIVM;
            ErrorImage.Source = ConvertByteArrayToImage(Inquiry.Image);


        }

        private void Slet_Click(object sender, RoutedEventArgs e)
        {
            SendResponseWindow sendResponseWindow = new SendResponseWindow(RIVM.Inquiry);
            sendResponseWindow.Show(); 
        }
        public BitmapImage ConvertByteArrayToImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0)
                return null;

            BitmapImage image = new BitmapImage();
            using (MemoryStream ms = new MemoryStream(imageData))
            {
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = ms;
                image.EndInit();
            }
            image.Freeze(); // Prevents memory leaks in UI-bound scenarios
            return image;
        }
    }
}
