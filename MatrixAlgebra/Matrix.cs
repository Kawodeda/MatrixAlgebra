using System.Numerics;

namespace MatrixAlgebra
{
    public class Matrix<T> where T : INumber<T>
    {
        private readonly T[,] _elements;

        public Matrix(T[,] elements)
        {
            _elements = elements.Clone() as T[,] 
                ?? new T[0, 0];
        }

        public T this[int i, int j]
        {
            get
            {
                if (i < 0 || i >= Width)
                {
                    throw new ArgumentOutOfRangeException(nameof(i));
                }
                if (j < 0 || j >= Height)
                {
                    throw new ArgumentOutOfRangeException(nameof(j));
                }

                return _elements[i, j];
            }
        }

        public int Width
        {
            get
            {
                return _elements.GetLength(0);
            }
        }

        public int Height
        {
            get
            {
                return _elements.GetLength(1);
            }
        }

        public Vector<T> GetColumn(int i)
        {
            if (i < 0 && i >= Width)
            {
                throw new ArgumentOutOfRangeException(nameof(i));
            }

            var column = new T[Height];
            for (int j = 0; j < Height; j++)
            {
                column[j] = _elements[i, j];
            }

            return new Vector<T>(column);
        }

        public Vector<T> GetRow(int j)
        {
            if (j < 0 && j >= Height)
            {
                throw new ArgumentOutOfRangeException(nameof(j));
            }

            var row = new T[Width];
            for (int i = 0; i < Width; i++)
            {
                row[i] = _elements[i, j];
            }

            return new Vector<T>(row);
        }

        public Matrix<T> Add(Matrix<T> other)
        {
            if (!SameSize(other))
            {
                throw new ArgumentException("The other Matrix was of different size");
            }

            var sum = new T[Width, Height];
            for (int i = 0; i < Width; i++)
            {
                for(int j = 0; j < Height; j++)
                {
                    sum[i, j] = _elements[i, j] + other[i, j];
                }
            }

            return new Matrix<T>(sum);
        }

        public Matrix<T> Subtract(Matrix<T> other)
        {
            if (!SameSize(other))
            {
                throw new ArgumentException("The other Matrix was of different size");
            }

            return Add(other.Multiply(-T.One));
        }

        public Matrix<T> Multiply(T scalar)
        {
            var product = new T[Width, Height];
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    product[i, j] = _elements[i, j] * scalar;
                }
            }

            return new Matrix<T>(product);
        }

        public Matrix<T> Multiply(Matrix<T> other)
        {
            if (Width != other.Height)
            {
                throw new ArgumentException("Height of the other Matrix was not equal to Width");
            }

            var product = new T[other.Width, Height];
            for (int i = 0; i < other.Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    product[i, j] = GetRow(j).DotProduct(other.GetColumn(i));
                }
            }

            return new Matrix<T>(product);
        }

        public Matrix<T> Transpose()
        {
            var result = new T[Height, Width];
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    result[j, i] = _elements[i, j];
                }
            }

            return new Matrix<T>(result);
        }

        public bool SameSize(Matrix<T> other)
        {
            return Width == other.Width && Height == other.Height;
        }

        public bool Equals(Matrix<T> other, T epsilon)
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    if (!GenericMath.NearlyEquals(_elements[i, j], other[i, j], epsilon))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
