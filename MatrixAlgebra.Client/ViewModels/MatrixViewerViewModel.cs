using MatrixAlgebra.Client.Dto;
using MatrixAlgebra.Client.ViewModels.Commands;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;

namespace MatrixAlgebra.Client.ViewModels
{
    public class MatrixViewerViewModel : MatrixViewerViewModel<float>
    {

    }

    public class MatrixViewerViewModel<T> : BaseViewModel where T : INumber<T>
    {
        private const int MinRows = 1;
        private const int MaxRows = 10;
        private const int MinColumns = 1;
        private const int MaxColumns = 10;

        private readonly T DefaultElement = T.Zero;
        private readonly ObservableCollection<ObservableCollection<T>> _matrix = new ObservableCollection<ObservableCollection<T>>()
        {
            new ObservableCollection<T>() { T.Zero, T.Zero, T.Zero },
            new ObservableCollection<T>() { T.Zero, T.Zero, T.Zero },
            new ObservableCollection<T>() { T.Zero, T.Zero, T.Zero }
        };

        private string _title = "";

        public MatrixViewerViewModel()
        {
            AddColumnCommand = new RelayCommand(parameter => AddColumn(), parameter => CanAddColumn());
            AddRowCommand = new RelayCommand(parameter => AddRow(), parameter => CanAddRow());
            RemoveColumnCommand = new RelayCommand(parameter => RemoveColumn(), parameter => CanRemoveColumn());
            RemoveRowCommand = new RelayCommand(parameter => RemoveRow(), parameter => CanRemoveRow());
        }

        public int Columns
        {
            get
            {
                return _matrix.Count;
            }
        }

        public int Rows
        {
            get
            {
                return _matrix.Select(column => column.Count).Max();
            }
        }

        public ObservableCollection<ObservableCollection<T>> Matrix
        {
            get
            {
                return _matrix;
            }
        }

        public bool IsReadOnly { get; set; }

        public bool AllowChangeSize { get; set; } = true;

        public string Title 
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                NotifyPropertyChanged(nameof(Title));
            }
        }

        public RelayCommand AddColumnCommand { get; }

        public RelayCommand RemoveColumnCommand { get; }

        public RelayCommand AddRowCommand { get; }

        public RelayCommand RemoveRowCommand { get; }

        public bool ShowChangeSizeButtons
        {
            get
            {
                return AllowChangeSize && !IsReadOnly;
            }
        }

        public event EventHandler<int>? RowsChanged;

        public event EventHandler<int>? ColumnsChanged;

        public void SetMatrix(MatrixDto<T> matrix)
        {
            _matrix.Clear();
            for (int i = 0; i < matrix.Elements.GetLength(0); i++)
            {
                _matrix.Add(new ObservableCollection<T>());
                for (int j = 0; j < matrix.Elements.GetLength(1); j++)
                {
                    _matrix[i].Add(matrix.Elements[i, j]);
                }
            }

            RowsChanged?.Invoke(this, Rows);
            ColumnsChanged?.Invoke(this, Columns);
        }

        public MatrixDto<T> GetMatrix()
        {
            var result = new T[Columns, Rows];
            for (int i = 0; i < Columns; i++)
            {
                for (int j = 0; j < Rows; j++)
                {
                    result[i, j] = _matrix[i][j];
                }
            }

            return new MatrixDto<T>(result);
        }

        public T[] GetColumn(int columnIndex)
        {
            return Matrix[columnIndex].ToArray();
        }

        public T[] GetRow(int rowIndex)
        {
            var result = new T[Columns];
            for (int i = 0; i < Rows; i++)
            {
                result[i] = Matrix[i][rowIndex];
            }

            return result;
        }

        private bool CanAddRow()
        {
            return Rows < MaxRows && !IsReadOnly;
        }

        private void AddRow()
        {
            foreach (var column in _matrix)
            {
                column.Add(DefaultElement);
            }

            OnRowsChanged();
        }

        private bool CanRemoveRow()
        {
            return Rows > MinRows && !IsReadOnly;
        }

        private void RemoveRow()
        {
            foreach (var column in _matrix)
            {
                column.RemoveAt(Rows - 1);
            }

            OnRowsChanged();
        }

        private bool CanAddColumn()
        {
            return Columns < MaxColumns && !IsReadOnly;
        }

        private void AddColumn()
        {
            var column = Enumerable.Repeat(DefaultElement, Rows);
            _matrix.Add(new ObservableCollection<T>(column));

            OnColumnsChanged();
        }

        private bool CanRemoveColumn()
        {
            return Columns > MinColumns && !IsReadOnly;
        }

        private void RemoveColumn()
        {
            _matrix.RemoveAt(Columns - 1);

            OnColumnsChanged();
        }

        private void OnColumnsChanged()
        {
            AddColumnCommand.NotifyCanExecuteChanged();
            RemoveColumnCommand.NotifyCanExecuteChanged();
            ColumnsChanged?.Invoke(this, Columns);
        }

        private void OnRowsChanged()
        {
            AddRowCommand.NotifyCanExecuteChanged();
            RemoveRowCommand.NotifyCanExecuteChanged();
            RowsChanged?.Invoke(this, Rows);
        }
    }
}