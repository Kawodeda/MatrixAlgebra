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
            new MatrixAddOperation(),
            new MatrixSubtractOperation(),
            new MatrixScaleOperation(),
            new MatrixTransposeOperation(),
            new MatrixMultiplyByTransposedOperation(),
            new MatrixSwapRowsOperation(),
            new MatrixTransposeRowsOperation(),
            new MatrixInverseOperation()
        };

        private IMatrixOperation _selectedOperation = new MatrixNoneOperation();

        public MainViewModel()
        {
            CalculateCommand = new RelayCommand(Calculate, CanCalculate);
            MatrixAViewModel.RowsChanged += OnMatrixARowsChanged;
            UpdateTranspositionVector(MatrixAViewModel.Rows);
            MatrixAViewModel.Title = SelectedOperation.ViewState.MatrixATitle;
        }

        public IEnumerable<IMatrixOperation> Operations
        {
            get
            {
                return _operations;
            }
        }

        public IMatrixOperation SelectedOperation
        {
            get
            {
                return _selectedOperation;
            }
            set
            {
                _selectedOperation = value;
                CalculateCommand.NotifyCanExecuteChanged();

                NotifyPropertyChanged(nameof(SelectedOperation));
            }
        }

        public MatrixViewerViewModel MatrixAViewModel { get; } = new MatrixViewerViewModel();

        public MatrixViewerViewModel MatrixBViewModel { get; } = new MatrixViewerViewModel()
        {
            Title = "B"
        };

        public MatrixViewerViewModel TranspositionVectorViewModel { get; } = new MatrixViewerViewModel()
        {
            Title = "Transposition vector",
            AllowChangeSize = false,
        };

        public MatrixViewerViewModel MatrixResultViewModel { get; } = new MatrixViewerViewModel()
        {
            Title = "Result",
            IsReadOnly = true
        };

        public int Row1Index { get; set; }

        public int Row2Index { get; set; }

        public RelayCommand CalculateCommand { get; }

        private void Calculate(object? parameter)
        {
            MatrixDto matrixA = MatrixAViewModel.GetMatrix();
            MatrixDto matrixB = MatrixBViewModel.GetMatrix();
            MatrixDto result = SelectedOperation.Perform(
                new MatrixOperationContext(
                    matrixA, 
                    matrixA, 
                    matrixB, 
                    0, 
                    0, 
                    1, 
                    null));

            MatrixResultViewModel.SetMatrix(result);
        }

        private bool CanCalculate(object? parameter)
        {
            return SelectedOperation != null;
        }

        private void OnMatrixARowsChanged(object? sender, int rows)
        {
            UpdateTranspositionVector(rows);
        }

        private void UpdateTranspositionVector(int rows)
        {
            TranspositionVectorViewModel.SetMatrix(new MatrixDto(new float[1, rows]));
        }
    }
}