using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using WorkAssistant.Core;
using WorkAssistant.MVVM.ViewModel;

namespace WorkAssistant
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _closed = "M3,6H21V8H3V6M3,11H21V13H3V11M3,16H21V18H3V16Z";
        private string _expanded = "M21,15.61L19.59,17L14.58,12L19.59,7L21,8.39L17.44,12L21,15.61M3,6H16V8H3V6M3,13V11H13V13H3M3,18V16H16V18H3Z";
        private bool _isExpanded = false;

        public MainWindow(IOptions<Api> api)
        {
            InitializeComponent();
            DataContext = new MainViewModel(api.Value, LoginService.Instance.EventAggregator);
            Expander.Data = Geometry.Parse(_closed);
        }


        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (_isExpanded)
            {
                Expander.Data = Geometry.Parse(_closed);
                _isExpanded = false;
                Grid.ColumnDefinitions[0].Width = new GridLength(80);
                MenuBar.Width = 40;
                return;
            }

            Expander.Data = Geometry.Parse(_expanded);
            Grid.ColumnDefinitions[0].Width = new GridLength(290);
            MenuBar.Width = 250;
            _isExpanded = true;
        }

        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
