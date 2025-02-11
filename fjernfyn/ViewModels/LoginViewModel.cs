using Microsoft.Extensions.Configuration;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Windows.Input;

namespace fjernfyn
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private readonly string con;
        
        public ICommand loginCommand { get; }



        public LoginViewModel() 
        {
            loginCommand = new CommandHandler(OnLoginClicked);
            
         
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnLoginClicked() 
        {
            
        }

        protected void OnPropertyChanged(string propertyName)

        {
            var value = this.GetType().GetProperty(propertyName)?.GetValue(this, null);

            Debug.WriteLine($"Property: {propertyName}, Value: {value}");


            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;

            if (propertyChanged != null)

            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));

            }

        }


    }
}
