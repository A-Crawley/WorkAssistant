using System.Windows.Controls;
using WorkAssistant.Core;
using WorkAssistant.MVVM.ViewModel;

namespace WorkAssistant.MVVM.View
{
    /// <summary>
    /// Interaction logic for DashboardView.xaml
    /// </summary>
    public partial class DashboardView : UserControl
    {
        public DashboardView()
        {
            InitializeComponent();
            DataContext = new DashboardViewModel();
        }
    }
}
