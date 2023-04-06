using MatrixAlgebra.Client.Dto;
using MatrixAlgebra.Client.ViewModels.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace MatrixAlgebra.Client.ViewModels
{
    public class MatrixViewerViewModel : BaseViewModel
    {
        private const float DefaultElement = 0f;
        private const int MinRows = 1;
        private const int MaxRows = 10;
        private const int MinColumns = 1;
        private const int MaxColumns = 10;

        private readonly ObservableCollection<ObservableCollection<float>> _matrix = new ObservableCollection<ObservableCollection<float>>()
        {
            new ObservableCollection<float>() { 0, 0, 0 },
            new ObservableCollection<float>() { 1, 2, 3 }
        };

        private int Columns
        {
            get
            {
                return _matrix.Count;
            }
        }

        private int Rows
        {
            get
            {
                return _matrix.Select(column => column.Count).Max();
            }
        }

        public ObservableCollection<ObservableCollection<float>> Matrix
        {
            get
            {
                return _matrix;
            }
        }

        public RelayCommand AddColumnCommand { get; }

        public RelayCommand RemoveColumnCommand { get; }

        public RelayCommand AddRowCommand { get; }

        public RelayCommand RemoveRowCommand { get; }

        public MatrixViewerViewModel()
        {
            AddColumnCommand = new RelayCommand(parameter => AddColumn(), parameter => CanAddColumn());
            AddRowCommand = new RelayCommand(parameter => AddRow(), parameter => CanAddRow());
            RemoveColumnCommand = new RelayCommand(parameter => RemoveColumn(), parameter => CanRemoveColumn());
            RemoveRowCommand = new RelayCommand(parameter => RemoveRow(), parameter => CanRemoveRow());
        }

        public void SetMatrix(MatrixDto matrix)
        {
            _matrix.Clear();
            for (int i = 0; i < matrix.Elements.GetLength(0); i++)
            {
                _matrix.Add(new ObservableCollection<float>());
                for (int j = 0; j < matrix.Elements.GetLength(1); j++)
                {
                    _matrix[i].Add(matrix.Elements[i, j]);
                }
            }
        }

        public MatrixDto GetMatrix()
        {
            var result = new float[Columns, Rows];
            for (int i = 0; i < Columns; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    result[i, j] = _matrix[i][j];
                }
            }

            return new MatrixDto(result);
        }

        private bool CanAddRow()
        {
            return Rows < MaxRows;
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
            return Rows > MinRows;
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
            return Columns < MaxColumns;
        }

        private void AddColumn()
        {
            var column = Enumerable.Repeat(DefaultElement, Rows);
            _matrix.Add(new ObservableCollection<float>(column));

            OnColumnsChanged();
        }

        private bool CanRemoveColumn()
        {
            return Columns > MinColumns;
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
        }

        private void OnRowsChanged()
        {
            AddRowCommand.NotifyCanExecuteChanged();
            RemoveRowCommand.NotifyCanExecuteChanged();
        }
    }
}