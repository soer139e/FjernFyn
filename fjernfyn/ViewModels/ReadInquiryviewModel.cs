using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using fjernfyn.Services;

namespace fjernfyn.ViewModels
{
    public class ReadInquiryViewModel
    {
        private EmailSendingService _emailSendingService;

        public ICommand SendEmailCommand { get; }
        public ReadInquiryViewModel()
        {
            _emailSendingService = new EmailSendingService();
            SendEmailCommand =new CommandHandler(SendEmail);
            
        }

        public void SendEmail()
        {
       
            _emailSendingService.SendEmail("Soren.Ploug04@gmail.com", "test af program", "Dette er en test af EmailSendingService");
        }
    }
}
