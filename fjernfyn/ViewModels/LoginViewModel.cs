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
            sendInformation();
        }

        private Employee sendInformation()
        {
            string userInfo = empRepo.HandleInformation(UserName, Password);
            string[] splitString = userInfo.Split("|");
            Employee finalEmp = null;

            if (splitString.Length > 1)
            {
                MessageBox.Show("yeah, we logged in... 😏😏😏", "success");
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
