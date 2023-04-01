using System.Numerics;

namespace MatrixAlgebra
{
    public class SquareMatrix<T> where T : INumber<T>
    {
        private readonly Matrix<T> _matrix;

        public SquareMatrix(Matrix<T> matrix)
        {
            if (matrix.Width != matrix.Height)
            {
                throw new ArgumentException("The width and heigth of matrix were not equal");
            }

            _matrix = matrix;
        }

        public SquareMatrix(T[,] elements) 
            : this(new Matrix<T>(elements)) { }

        public Matrix<T> Matrix
        {
            get
            {
                return _matrix;
            }
        }

        public int Size
        {
            get
            {
                return Matrix.Width;
            }
        }

        public SquareMatrix<T> Inverse()
        {
            return AdjugateMatrix().Multiply(T.One / Determinant());
        }

        public SquareMatrix<T> Transpose()
        {
            return new SquareMatrix<T>(Matrix.Transpose());
        }

        public SquareMatrix<T> Multiply(T scalar)
        {
            return new SquareMatrix<T>(Matrix.Multiply(scalar));
        }

        public bool Equals(SquareMatrix<T> other, T epsilon)
        {
            return Matrix.Equals(other.Matrix, epsilon);
        }

        private SquareMatrix<T> AdjugateMatrix()
        {
            SquareMatrix<T> transposed = Transpose();
            var result = new T[Size, Size];
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    result[i, j] = GenericMath.Pow(-T.One, i + j) * transposed.Minor(i, j);
                }
            }

            return new SquareMatrix<T>(result);
        }

        private T Determinant()
        {
            T result = T.AdditiveIdentity;
            for (int j = 0; j < Size; j++)
            {
                result += GenericMath.Pow(-T.One, 1 + j) * Matrix[1, j] * Minor(1, j);
            }

            return result;
        }

        private T Minor(int i, int j)
        {
            return Submatrix(i, j).Determinant();
        }

        private SquareMatrix<T> Submatrix(int i, int j)
        {
            int iResult = 0;
            int jResult = 0;
            var result = new T[Size - 1, Size - 1];

            for (int iCurrent = 0; iCurrent < Size; iCurrent++)
            {
                if (iCurrent == i)
                {
                    continue;
                }
                for (int jCurrent = 0; jCurrent < Size; jCurrent++)
                {
                    if (jCurrent == j)
                    {
                        continue;
                    }

                    result[iResult, jResult] = Matrix[iCurrent, jCurrent];
                    iResult++;
                    jResult++;
                }
            }

            return new SquareMatrix<T>(result);
        }
    }
}