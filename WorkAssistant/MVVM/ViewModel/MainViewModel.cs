using Prism.Events;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using WorkAssistant.Core;
using WorkAssistant.MVVM.View;

namespace WorkAssistant.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        private readonly Api _api;
        private object _currentView;
        private Guid _token;

        public object CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel(Api api, IEventAggregator eventAggregator)
        {
            _api = api;
            eventAggregator.GetEvent<LoginEvent>().Subscribe(Login, ThreadOption.UIThread);
            CurrentView = new LoginViewModel(LoginService.Instance.EventAggregator);
            //ChangeWindow(nameof(DashboardViewModel));
        }

        public async void Login(string[] param)
        {
            var username = param[0];
            var password = param[1];

            try
            {

                var response = await RestClient.PutJsonAsync(_api.Account, "login",
                    new {username, password});

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    var responseMessage = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Login Not Successful | {responseMessage}");
                    return;
                }

                _token = Guid.Parse((await response.Content.ReadAsStringAsync()).Trim('"'));

                MessageBox.Show($"Fetched token | {_token}");
            }
            catch (Exception e)
            {
                MessageBox.Show($"Login Not Successful | {e.Message}");
                return;
            }

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
