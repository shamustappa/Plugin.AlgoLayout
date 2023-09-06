using System;
using System.Windows;
using AlgoLayout.RhinoPlugin.UI;

namespace AlgoLayout.RhinoPlugin.UI
{
    /// <summary>
    /// Interaction logic for LayoutForm.xaml
    /// </summary>
    public partial class LayoutForm : Window
    {
        public LayoutViewModel ViewModel { get; set; }

        public LayoutForm()
        {
            InitializeComponent();
            ViewModel = new LayoutViewModel();
            DataContext = ViewModel;
        }

        private void RunLayoutButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.RunLayoutCommand.Execute(null);
        }

        private void StopLayoutButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.StopLayoutCommand.Execute(null);
        }

        private void ExportLayoutButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.ExportLayoutCommand.Execute(null);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            // Perform any cleanup or resource release here
        }
    }
}
