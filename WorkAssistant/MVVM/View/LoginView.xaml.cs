using System.Windows;
using System.Windows.Controls;
using WorkAssistant.Core;
using WorkAssistant.MVVM.ViewModel;

namespace WorkAssistant.MVVM.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
            DataContext = new LoginViewModel(LoginService.Instance.EventAggregator);
        }

        private void PasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            var pass = (PasswordBox)sender;

            if (pass.SecurePassword.Length == 0)
                PasswordHint.Visibility = Visibility;
            else
                PasswordHint.Visibility = Visibility.Hidden;
        }
    }
}
