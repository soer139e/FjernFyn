using fjernfyn.Classes;
using fjernfyn.Repositories;
using Microsoft.Win32;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.IO;

namespace fjernfyn
{
    public class FeedbackCreateViewModel : INotifyPropertyChanged
    {
        public List<Software> softwares {  get; set; }
        private FeedbackRepo feedbackRepo;
        private SoftwaresRepo softwareRepo { get; set; }


        private Window feedbackWindow {  get; set; }

        public Feedback Feedback { get; set; }

        public Employee Employee { get; set; }

        public ICommand sendCommand { get; }
        //public ICommand addSoftwareCommand { get; }
        public ICommand AddErrorImageCommand { get; }

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

        public List<Category> Categorys { get; } = new List<Category>() { Category.Bug, Category.Feature, Category.Request };
        public List<Priority> Prioritys { get; } = new List<Priority>() { Priority.High, Priority.Medium, Priority.Low};
        /// <summary>
        /// TOOD: implement the employee class inside the constructor, call the employee so that we can fetch the information and databind it across views.
        /// </summary>
        public FeedbackCreateViewModel(Window window, Employee emp) 
        {
            feedbackRepo = new FeedbackRepo();

            softwareRepo = new SoftwaresRepo();
            softwares = new List<Software>();

            AddErrorImageCommand = new CommandHandler(AddErrorImage);
            softwares = softwareRepo.GetAll();
            sendCommand = new CommandHandler(SendClicked);
            //addSoftwareCommand = new CommandHandler(PlusClicked);
            //TODO: We need to either
            // A. remove the explicit Feedback constructor
            // B. somehow gather all the information already premade here...

            // In my personal opinion, going with option A, not only gives us consistency throughout the code,
            // but is also objectively the better option if we want to not go insane writing this mess.
            Feedback = new Feedback();
            Feedback.Description = "Hvad prøver du at gøre?\n \r\nTrin-for-trin gengivelse\r\n \nHvad gjorde du, før problemet opstod:";
            Feedback.Image = null;
            Feedback.ErrorCode = "";
            feedbackWindow = window;
            Employee = emp;
        } 
        
        //public void PlusClicked()
        //{
        //    InputDialog dialog = new InputDialog();
        //    dialog.ShowDialog();
        //    software.Add(dialog.InputText);
        //    dialog.Close();
        //}
        public void SendClicked()
        {
            //Create feedback method isnt done yet.
            //TODO: DATABIND A SELECTED SOFTWARE AND OTHER DROP BOXES
            // Also.... maybe change the variable name
            // THESE ARE DUMMY VALUES! I BEG YOU!!!!
           
            //Software software = new Software();
            //software.Name = "Trello";
            //software.ID = 4;
            //Feedback.SoftwareProp = software;


            Feedback.Employee = Employee;
          
            feedbackRepo.CreateFeedback(Feedback);
           
            MessageBox.Show("Forespørgsel oprettet", "success");
        }
        public void AddErrorImage()
        {
            string result;
            OpenFileDialog Dialog  = new OpenFileDialog();

            if (Dialog.ShowDialog() == true)
            {
                result = Dialog.FileName;
                if (!string.IsNullOrEmpty(result) && File.Exists(result))
                {
                    Feedback.Image = File.ReadAllBytes(result);
                }

            }
            
            
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
