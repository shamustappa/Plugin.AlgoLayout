using System.ComponentModel;
using System.Windows.Input;
using Rhino;

namespace AlgoLayout.RhinoPlugin.UI
{
    public class LayoutViewModel : INotifyPropertyChanged
    {
        private int _numberOfRooms;
        private string _selectedAlgorithm;

        public int NumberOfRooms
        {
            get { return _numberOfRooms; }
            set
            {
                if (_numberOfRooms != value)
                {
                    _numberOfRooms = value;
                    OnPropertyChanged("NumberOfRooms");
                }
            }
        }

        public string SelectedAlgorithm
        {
            get { return _selectedAlgorithm; }
            set
            {
                if (_selectedAlgorithm != value)
                {
                    _selectedAlgorithm = value;
                    OnPropertyChanged("SelectedAlgorithm");
                }
            }
        }

        public ICommand RunOptimizationCommand { get; private set; }

        public LayoutViewModel()
        {
            RunOptimizationCommand = new RelayCommand(RunOptimization);
        }

        private void RunOptimization()
        {
            // Call Rhino command to run the optimization
            RhinoApp.RunScript($"RunLayoutOptimization {NumberOfRooms} {SelectedAlgorithm}", true);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
