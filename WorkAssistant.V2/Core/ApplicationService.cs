using Prism.Events;

namespace WorkAssistant.Core
{
    internal sealed class LoginService
    {
        private LoginService() { }

        private static readonly LoginService _instance = new LoginService();

        internal static LoginService Instance { get { return _instance; } }

        private IEventAggregator _eventAggregator;
        internal IEventAggregator EventAggregator
        {
            get
            {
                if (_eventAggregator == null)
                    _eventAggregator = new EventAggregator();

                return _eventAggregator;
            }
        }
    }
}
