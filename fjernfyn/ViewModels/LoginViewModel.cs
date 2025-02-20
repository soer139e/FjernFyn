using fjernfyn.Repositories;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace fjernfyn
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public Employee Employee { get; set; }

        private readonly EmployeeRepository empRepo;

        //private GlobalValues glob = new GlobalValues();
        public ICommand loginCommand { get; }

        private FeedbackCreationWindow nextWindow; 

        private Employee _selectedEmp;

        public Employee SelectedEmp
        {
            get { return _selectedEmp; }
            set { _selectedEmp = value; OnPropertyChanged(nameof(SelectedEmp)); }
        }

        public MainWindow Window { get; set; }

        public LoginViewModel(MainWindow window)
        {
            Window = window;
            Employee = new Employee();
            // TODO: Create an instance of employee class, instead of having username and password bindings here.
            loginCommand = new CommandHandler(OnLoginClicked);
            empRepo = new EmployeeRepository();
        }

        public event PropertyChangedEventHandler? PropertyChanged;


        /// <summary>
        /// For some weird reason, changing the return type of this bound command to employee, results in everything going wrong.
        /// So we need to have this OnLoginClicked method, which then instantly calls the SendInformation method.
        /// Since binding to a command with a return type isnt allowed since its of an Action datatype... thank you microsoft.
        /// </summary>
        private void OnLoginClicked()
        {
            if (empRepo.HandleInformation(Employee))
            {
                nextWindow = new FeedbackCreationWindow(Employee);
                nextWindow.Show();
                Window.Close();
                //MessageBox.Show($"Velkommen: {splitString[4]} ({splitString[2]})\n\n\nHusk at være grundig i din feedback.", "Logget ind");
            }
            else
            {
                MessageBox.Show("Der skete en fejl under login.", "Fejl");

            }
        }


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