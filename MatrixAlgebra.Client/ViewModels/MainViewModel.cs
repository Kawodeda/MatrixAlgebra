using MatrixAlgebra.Client.Dto;
using MatrixAlgebra.Client.MatrixOperations;
using MatrixAlgebra.Client.ViewModels.Commands;
using System.Collections.Generic;
using System.Linq;

namespace MatrixAlgebra.Client.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IEnumerable<IMatrixOperation> _operations = new List<IMatrixOperation>()
        {
            new MatrixAddOperation()
        };
        private readonly List<List<float>> _matrixA = new List<List<float>>();

        private IMatrixOperation? _selectedOperation;

        public MainViewModel()
        {
            _matrixA.Add(new List<float>() { 0, 0, 0 });
            CalculateCommand = new RelayCommand(Calculate, CanCalculate);
            MatrixAViewModel = new MatrixViewerViewModel();
            MatrixAViewModel.SetMatrix(new MatrixDto(new float[,] { { 11 } }));
        }

        public IEnumerable<IMatrixOperation> Operations
        {
            get
            {
                return _operations;
            }
        }

        public IMatrixOperation? SelectedOperation
        {
            get
            {
                return _selectedOperation;
            }
            set
            {
                _selectedOperation = value;
                CalculateCommand.NotifyCanExecuteChanged();
            }
        }

        public MatrixViewerViewModel MatrixAViewModel { get; }

        public RelayCommand CalculateCommand { get; }

        private void Calculate(object? parameter)
        {

        }

        private bool CanCalculate(object? parameter)
        {
            return SelectedOperation != null;
        }
    }
}
