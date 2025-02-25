using Azure.Messaging;
using fjernfyn.Classes;
using fjernfyn.Repositories;
using fjernfyn.Windows;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace fjernfyn
{
    public class FeedbackCreateViewModel : INotifyPropertyChanged
    {
        public List<string> softwares {  get; set; }
        private FeedbackRepo feedbackRepo {  get; set; }

        private Window feedbackWindow {  get; set; }

        public Feedback Feedback { get; set; }

        public Employee Employee { get; set; }
        
        public ICommand sendCommand { get; }
        public ICommand addSoftwareCommand { get; }

        private string? _employeeName;

        public string? EmployeeName
        {
            get { return _employeeName; }
            set { _employeeName = value; OnPropertyChanged(nameof(EmployeeName)); }
        }

        private string? _email;

        public string? Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged(nameof(Email));}
        }

        private string? _department;
        
        public string? Department
        {
            get { return _department; }
            set { _department = value; OnPropertyChanged(nameof(Department));}
        }

        private string? _feedbackContent;

        public string? FeedbackContent;


        /// <summary>
        /// TOOD: implement the employee class inside the constructor, call the employee so that we can fetch the information and databind it across views.
        /// </summary>
        public FeedbackCreateViewModel(Window window, Employee emp) 
        {
            softwares = new List<string>();

            sendCommand = new CommandHandler(SendClicked);
            addSoftwareCommand = new CommandHandler(PlusClicked);
            //TODO: We need to either
            // A. remove the explicit Feedback constructor
            // B. somehow gather alll the information already premade here...

            // In my personal opinion, going with option A, not only gives us consistency throughout the code,
            // but is also objectively the better option if we want to not go insane writing this mess.
            Feedback = new Feedback();

            feedbackWindow = window;
            Employee = emp;
        } 
        
        public void PlusClicked()
        {
            InputDialog dialog = new InputDialog();
            dialog.ShowDialog();
            softwares.Add(dialog.InputText);
            dialog.Close();
        }
        public void SendClicked()
        {
            //Create feedback method isnt done yet.
            feedbackRepo.CreateFeedback(Feedback);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            var value = this.GetType().GetProperty(propertyName)?.GetValue(this, null);
            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
