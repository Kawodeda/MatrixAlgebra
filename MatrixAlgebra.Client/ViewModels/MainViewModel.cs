using MatrixAlgebra.Client.Dto;
using MatrixAlgebra.Client.MatrixOperations;
using MatrixAlgebra.Client.ViewModels.Commands;
using System.Collections.Generic;

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

        public MatrixViewerViewModel MatrixAViewModel { get; } = new MatrixViewerViewModel();

        public MatrixViewerViewModel MatrixBViewModel { get; } = new MatrixViewerViewModel();

        public MatrixViewerViewModel MatrixResultViewModel { get; } = new MatrixViewerViewModel();

        public RelayCommand CalculateCommand { get; }

        private void Calculate(object? parameter)
        {
            MatrixDto matrixA = MatrixAViewModel.GetMatrix();
            MatrixDto matrixB = MatrixBViewModel.GetMatrix();
            MatrixDto result = SelectedOperation!.Perform(new MatrixOperationContext(matrixA, matrixA, matrixB));

            MatrixResultViewModel.SetMatrix(result);
        }

        private bool CanCalculate(object? parameter)
        {
            return SelectedOperation != null;
        }
    }
}
