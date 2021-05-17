using Prism.Events;
using System;
using WorkAssistant.Core;
using WorkAssistant.MVVM.View;

namespace WorkAssistant.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        private object _currentView;

        public object CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel(IEventAggregator eventAggregator)
        {
            eventAggregator.GetEvent<LoginEvent>().Subscribe(Login, ThreadOption.UIThread);
            CurrentView = new LoginViewModel(LoginService.Instance.EventAggregator);
            //ChangeWindow(nameof(DashboardViewModel));
        }

        public void Login(string[] param)
        {
            var username = param[0];
            var password = param[1];

            ChangeWindow(nameof(DashboardViewModel));
        }

        public void ChangeWindow(string type)
        {
            switch (type)
            {
                case nameof(LoginViewModel):
                    CurrentView = new LoginViewModel(LoginService.Instance.EventAggregator);
                    break;
                case nameof(DashboardViewModel):
                    CurrentView = new DashboardViewModel();
                    break;
                default:
                    break;
            }
        }
    }
}
