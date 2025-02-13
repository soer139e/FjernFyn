using fjernfyn.Repositories;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace fjernfyn
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private readonly EmployeeRepository _employeeRepository;

        public LoginViewModel()
        {
            _employeeRepository = new EmployeeRepository();
        }

        public ICommand LoginCommand => new CommandHandler(OnLoginClicked);

        public string UserName { get; set; }
        public string Password { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnLoginClicked()
        {
            var employee = Login();

            if (employee != null)
            {
                MessageBox.Show($"Velkommen: {employee.Username} ({employee.Email})\n\n\nHusk at være grundig i din feedback.", "Logget ind");
            }
            else
            {
                MessageBox.Show("Der skete en fejl under login (6x624)", "Fejl");
            }
        }

        public Employee Login()
        {
            string userInfo = _employeeRepository.HandleInformation(UserName, Password);
            string[] splitString = userInfo.Split("|");

            if (splitString.Length > 1)
            {
                Employee employee = new Employee(splitString[0], splitString[1], splitString[2], (Department)Enum.Parse(typeof(Department), splitString[3]));
                return employee;
            }
            return null;
        }
    }

}