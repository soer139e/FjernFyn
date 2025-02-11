using System.Windows.Input;

namespace fjernfyn
{
    public class LoginViewModel
    {
        public ICommand loginCommand { get; }

        public LoginViewModel() 
        {
            loginCommand = new CommandHandler(OnLoginClicked);
        }

        private void OnLoginClicked() { }


    }
}
