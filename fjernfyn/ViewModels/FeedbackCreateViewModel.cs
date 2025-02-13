using System.ComponentModel;
using System.Windows;

namespace fjernfyn
{
    public class FeedbackCreateViewModel : INotifyPropertyChanged
    {
        private GlobalValues _values;


        private string _employeeName;

        public string EmployeeName
        {
            get { return _employeeName; }
            set { _employeeName = value; OnPropertyChanged(nameof(EmployeeName)); }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged(nameof(Email));}
        }

        private string _department;
        
        public string Department
        {
            get { return _department; }
            set { _department = value; OnPropertyChanged(nameof(Department));}
        }

        private string _feedbackContent;

        public string FeedbackContent;


        /// <summary>
        /// TOOD: Implement INotifyPropertyChanged whenever we get to that.
        /// </summary>
        public FeedbackCreateViewModel() 
        {
            _values = new GlobalValues();
            try
            {
                EmployeeName = _values.CurrentEmployee.Username;
                Email = _values.CurrentEmployee.Email;
                Department = $"{_values.CurrentEmployee.Department.ToString()}-Afdeling";
            } catch
            {
                MessageBox.Show("Fejl opstået ved forsøg på at logge ind. (9x347)", "Fejl");
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
