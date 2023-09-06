using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using AlgoLayout.RhinoPlugin.RhinoModels;
using AlgoLayout.RhinoPlugin.Commands;
using static NUnit.Framework.RetryAttribute;

namespace AlgoLayout.RhinoPlugin.UI
{
    public class LayoutViewModel : ViewModelBase
    {
        private RhinoLayout _rhinoLayout;
        private RhinoRoom _rhinoRoom;

        public ObservableCollection<GeometryBase> LayoutGeometry { get; set; }

        public ICommand RunLayoutCommand { get; set; }
        public ICommand StopLayoutCommand { get; set; }
        public ICommand ExportLayoutCommand { get; set; }

        public LayoutViewModel()
        {
            _rhinoLayout = new RhinoLayout();
            _rhinoRoom = new RhinoRoom();

            LayoutGeometry = new ObservableCollection<GeometryBase>();

            RunLayoutCommand = new RelayCommand(RunLayout);
            StopLayoutCommand = new RelayCommand(StopLayout);
            ExportLayoutCommand = new RelayCommand(ExportLayout);

            _rhinoLayout.LayoutAlgorithmCompleted += OnLayoutAlgorithmCompleted;
        }

        private void RunLayout()
        {
            _rhinoLayout.RunLayoutAlgorithm();
        }

        private void StopLayout()
        {
            _rhinoLayout.StopLayoutAlgorithm();
        }

        private void ExportLayout()
        {
            var exportedGeometry = _rhinoLayout.ExportLayout();
            // TODO: Implement export logic
        }

        private void OnLayoutAlgorithmCompleted(object sender, EventArgs e)
        {
            LayoutGeometry.Clear();
            foreach (var geo in _rhinoLayout.ExportLayout())
            {
                LayoutGeometry.Add(geo);
            }
        }
    }
}
