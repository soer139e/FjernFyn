using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using fjernfyn.Classes;
using fjernfyn.Interfaces;

using fjernfyn.Services;


namespace fjernfyn
{
    public class SendResponseViewModel
    {
        private Feedback _inquiryToRespond;

        private readonly IEmailSender _emailSendingService;

        private string body;

        public string Body
        {
            get { return body; }
            set { body = value; }
        }


        private string _title;     

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }


        public ICommand SendEmailCommand { get; }
        public SendResponseViewModel(Feedback inquiry)
        {
            
            _inquiryToRespond = inquiry;
            _emailSendingService = new EmailSendingService();

            SendEmailCommand = new CommandHandler(SendEmail);
        }
        public void SendEmail()
        {
            if (MessageBox.Show("Er du sikker på at du vil sende en mail.", "Bekræftelse", MessageBoxButton.YesNo, MessageBoxImage.Warning)== MessageBoxResult.Yes) 
            {
                try
                {
                    _emailSendingService.SendEmailAsync(_inquiryToRespond.Employee.Email, Title, Body);
                }
                catch {
                    MessageBox.Show("Ugyldig mail", "Fejl", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
