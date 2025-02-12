using fjernfyn.Repositories;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace fjernfyn
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private readonly string con;

        private EmployeeRepository empRepo = new EmployeeRepository();

        
        public ICommand loginCommand { get; }

        private string _userName;

        private string _password;

        private Employee _selectedEmp;


        public Employee SelectedEmp
        {
            get { return _selectedEmp; }
            set { _selectedEmp = value; OnPropertyChanged(nameof(SelectedEmp)); }
        }

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; OnPropertyChanged(nameof(UserName)); }
        }




        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(nameof(Password)); }
        }

        public LoginViewModel() 
        {
            loginCommand = new CommandHandler(OnLoginClicked);
        }

        public event PropertyChangedEventHandler? PropertyChanged;


        /// <summary>
        /// For some weird reason, changing the return type of this bound command to employee, results in everything going wrong.
        /// So we need to have this OnLoginClicked method, which then instantly calls the SendInformation method.
        /// Since binding to a command with a return type isnt allowed since its of an Action datatype... thank you microsoft.
        /// </summary>
        private void OnLoginClicked()  
        {
            sendInformation();
        }

        private Employee sendInformation()
        {
            string userInfo = empRepo.HandleInformation(UserName, Password);
            string[] splitString = userInfo.Split("|");
            Employee finalEmp = null;

            if (splitString.Length > 1)
            {
                finalEmp = new Employee(splitString[0], splitString[1], splitString[2], (Department)Enum.Parse(typeof(Department), splitString[3]));
                MessageBox.Show($"Velkommen: {splitString[4]} ({splitString[2]})\n\n\nHusk at være grundig i din feedback.", "Logget ind");
            } else
            {
                MessageBox.Show(userInfo, "Fejl");
            }
            return finalEmp;
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
