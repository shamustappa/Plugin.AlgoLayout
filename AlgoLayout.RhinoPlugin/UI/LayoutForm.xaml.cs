using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;
using Rhino;

namespace AlgoLayout.RhinoPlugin.UI
{
    /// <summary>
    /// Interaction logic for LayoutForm.xaml
    /// </summary>
    public partial class LayoutForm : Window
    {
        public LayoutForm()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, RoutedEventArgs e)
        {
            int numberOfRooms = int.Parse(txtNumberOfRooms.Text);
            string selectedAlgorithm = ((ComboBoxItem)cmbAlgorithm.SelectedItem).Content.ToString();

            // Call Rhino command to run the optimization
            RhinoApp.RunScript($"RunLayoutOptimization {numberOfRooms} {selectedAlgorithm}", true);

            this.Close();
        }
    }
}
