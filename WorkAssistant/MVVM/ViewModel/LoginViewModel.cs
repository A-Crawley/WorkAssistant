using Prism.Events;
using System.Windows.Input;
using WorkAssistant.Core;

namespace WorkAssistant.MVVM.ViewModel
{
    class LoginViewModel : ObservableObject
    {
        private ICommand _loginCommand;
        private string _username;
        private string _password;
        private readonly IEventAggregator _eventAggregator;

        public ICommand LoginCommand
        {
            get
            {
                if (_loginCommand == null)
                {
                    _loginCommand = new RelayCommand(
                        param => Login(),
                        param => CanLogin()
                    );
                }

                return _loginCommand;
            }
        }

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public LoginViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        private bool CanLogin()
            => Username?.Length > 0 || Password?.Length > 0;


        private void Login()
        {
            // Save command execution logic
            _eventAggregator.GetEvent<LoginEvent>().Publish(new[] { Username, Password });
        }
    }
}
