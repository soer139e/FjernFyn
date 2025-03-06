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
       public  Feedback Inquiry {  get; set; }
        public ReadInquiryViewModel(Feedback inquiry)
        { 
            Inquiry = inquiry;
        }

    }
}
