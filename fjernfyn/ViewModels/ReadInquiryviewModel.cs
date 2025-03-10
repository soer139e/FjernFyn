using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using fjernfyn.Services;
using fjernfyn.Interfaces;
using fjernfyn.Classes;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;

namespace fjernfyn.ViewModels
{
    public class ReadInquiryViewModel
    {

        public Feedback Inquiry { get; set; }
        public ReadInquiryViewModel(Feedback inquiry)
        {
            Inquiry = inquiry;

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
