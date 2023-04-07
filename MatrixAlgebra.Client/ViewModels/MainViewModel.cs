using MatrixAlgebra.Client.Dto;
using MatrixAlgebra.Client.MatrixOperations;
using MatrixAlgebra.Client.ViewModels.Commands;
using System.Collections.Generic;
using System.Collections.Specialized;
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
        private int _row1Index;
        private int _row2Index;

        public MainViewModel()
        {
            CalculateCommand = new RelayCommand(Calculate, CanCalculate);
            MatrixAViewModel.RowsChanged += OnMatrixARowsChanged;
            MatrixAViewModel.ColumnsChanged += OnMatrixAColumnsChanged;
            MatrixBViewModel.RowsChanged += OnMatrixBRowsChanged;
            MatrixBViewModel.ColumnsChanged += OnMatrixBColumnsChanged;
            UpdateTranspositionVector(MatrixAViewModel.Rows);
            MatrixAViewModel.Title = SelectedOperation.ViewState.MatrixATitle;
            TranspositionVectorViewModel.Matrix.Single().CollectionChanged += OnTranspositionVectorChanged;
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

        public MatrixViewerViewModel<float> MatrixAViewModel { get; } = new MatrixViewerViewModel<float>();

        public MatrixViewerViewModel<float> MatrixBViewModel { get; } = new MatrixViewerViewModel<float>()
        {
            Title = "B"
        };

        public MatrixViewerViewModel<int> TranspositionVectorViewModel { get; } = new MatrixViewerViewModel<int>()
        {
            Title = "Transposition vector",
            AllowChangeSize = false,
        };

        public MatrixViewerViewModel<float> MatrixResultViewModel { get; } = new MatrixViewerViewModel<float>()
        {
            Title = "Result",
            IsReadOnly = true
        };

        public float Scalar { get; set; }

        public int Row1Index
        {
            get
            {
                return _row1Index;
            }
            set
            {
                _row1Index = value;
                CalculateCommand.NotifyCanExecuteChanged();
            }
        }

        public int Row2Index
        {
            get
            {
                return _row2Index;
            }
            set
            {
                _row2Index = value;
                CalculateCommand.NotifyCanExecuteChanged();
            }
        }

        public RelayCommand CalculateCommand { get; }

        private IMatrixOperationContext MatrixOperationContext
        {
            get
            {
                MatrixDto matrixA = new MatrixDto(MatrixAViewModel.GetMatrix().Elements);
                MatrixDto matrixB = new MatrixDto(MatrixBViewModel.GetMatrix().Elements);
                TranspositionVectorDto transpositionVector = 
                    new TranspositionVectorDto(TranspositionVectorViewModel.Matrix.Single().ToArray());

                return new MatrixOperationContext(
                    matrixA,
                    matrixA,
                    matrixB,
                    Scalar,
                    Row1Index,
                    Row2Index,
                    transpositionVector);
            }
        }

        private void Calculate(object? parameter)
        {
            MatrixDto result = SelectedOperation.Perform(MatrixOperationContext);

            MatrixResultViewModel.SetMatrix(result);
        }

        private bool CanCalculate(object? parameter)
        {
            return SelectedOperation.CanPerform(MatrixOperationContext);
        }

        private void OnMatrixARowsChanged(object? sender, int rows)
        {
            UpdateTranspositionVector(rows);
            CalculateCommand.NotifyCanExecuteChanged();
        }

        private void OnMatrixAColumnsChanged(object? sender, int columns)
        {
            CalculateCommand.NotifyCanExecuteChanged();
        }

        private void OnMatrixBRowsChanged(object? sender, int rows)
        {
            CalculateCommand.NotifyCanExecuteChanged();
        }

        private void OnMatrixBColumnsChanged(object? sender, int columns)
        {
            CalculateCommand.NotifyCanExecuteChanged();
        }

        private void OnTranspositionVectorChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            CalculateCommand.NotifyCanExecuteChanged();
        }

        private void UpdateTranspositionVector(int rows)
        {
            TranspositionVectorViewModel.SetMatrix(new MatrixDto<int>(Enumerable.Range(0, rows).ToArray()));
            TranspositionVectorViewModel.Matrix.Single().CollectionChanged += OnTranspositionVectorChanged;
        }
    }
}