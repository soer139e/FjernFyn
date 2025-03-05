using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using fjernfyn.Services;
using fjernfyn.Interfaces;

namespace fjernfyn.ViewModels
{
    public class ReadInquiryViewModel
    {
        private readonly IEmailSender _emailSendingService;

        public ICommand SendEmailCommand { get; }
        public ReadInquiryViewModel()
        {
            _emailSendingService = new EmailSendingService();

            SendEmailCommand =new CommandHandler(SendEmail);
            
        }

        public void SendEmail()
        {
       
            _emailSendingService.SendEmailAsync("Soren.Ploug04@gmail.com", "test af program", "Dette er en test af EmailSendingService");
        }
    }
}
