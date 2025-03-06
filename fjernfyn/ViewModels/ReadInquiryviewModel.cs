using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using fjernfyn.Services;
using fjernfyn.Interfaces;
using fjernfyn.Classes;

namespace fjernfyn.ViewModels
{
    public class ReadInquiryViewModel
    {
       public Image Display { get; set; }
       public  Feedback Inquiry {  get; set; }
        public ReadInquiryViewModel(Feedback inquiry)
        { 
            Inquiry = inquiry;
            LoadImage(Inquiry.Image);
        }

        private static BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;

        }
    }
