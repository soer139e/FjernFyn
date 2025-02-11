using fjernfyn.Repositories;
using System.ComponentModel;
using System.Diagnostics;
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

        private void OnLoginClicked() 
        {
            Debug.WriteLine($"From OnLoginClicked: {UserName}, {Password}");
            sendInformation();
            // Should it do anything if it returns true/false or should we EXCLUSIVELY handle it in the repository.
        }

        private object sendInformation()
        {
            Debug.WriteLine($"From SendInformation: {UserName}, {Password}");


            string userInfo = empRepo.HandleInformation(UserName, Password);



            Employee finalEmp = null;

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
