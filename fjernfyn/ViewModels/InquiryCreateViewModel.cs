using fjernfyn.Classes;
using fjernfyn.Repositories;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace fjernfyn
{
    public class InquiryCreateViewModel : INotifyPropertyChanged
    {
        public List<string> software {  get; set; }
        private InquiryRepo inquiryRepo;
        private SoftwaresRepo softwaresRepo { get; set; }


        private Window InquiryWindow {  get; set; }

        public Inquiry Inquiry { get; set; }

        public Employee Employee { get; set; }

        public ICommand sendCommand { get; }
        //public ICommand addSoftwareCommand { get; }

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

        private string? _inquiryContent;

        public string? InquiryContent;


        /// <summary>
        /// TOOD: implement the employee class inside the constructor, call the employee so that we can fetch the information and databind it across views.
        /// </summary>
        public InquiryCreateViewModel(Window window, Employee emp) 
        {
            inquiryRepo = new InquiryRepo();

            softwaresRepo = new SoftwaresRepo();
            software = new List<string>();

            foreach (var obj in softwaresRepo.GetAll())
            {
                //maybe we should change this name too
                string[] cuck = obj.ToString().Split(";");
                software.Add(cuck[1]);
            }
            sendCommand = new CommandHandler(SendClicked);
            //addSoftwareCommand = new CommandHandler(PlusClicked);
            //TODO: We need to either
            // A. remove the explicit Feedback constructor
            // B. somehow gather all the information already premade here...

            // In my personal opinion, going with option A, not only gives us consistency throughout the code,
            // but is also objectively the better option if we want to not go insane writing this mess.
            Inquiry = new Inquiry();

            InquiryWindow = window;
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
           
            Software bitch = new Software();
            bitch.Name = "Trello";
            bitch.ID = 4;
            Inquiry.SoftwareProp = bitch;


            Inquiry.Employee = Employee;

            inquiryRepo.CreateInquiry(Inquiry);
            // TODO: change this fuckass message
            MessageBox.Show("godt gået... god dreng 👏👏👏👏👏👏👏", "success");
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
