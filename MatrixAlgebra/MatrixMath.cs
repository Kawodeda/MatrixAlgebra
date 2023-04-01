using System.Numerics;

namespace MatrixAlgebra
{
    public static class MatrixMath
    {
        public static Matrix<T> TransposeRows<T>(Matrix<T> matrix, Vector<int> transpositionVector) where T : INumber<T>
        {
            if (!ValidateTranspositionVector(matrix, transpositionVector))
            {
                throw new ArgumentException("The received transposition vector was not valid");
            }

            var result = new T[matrix.Width, matrix.Height];
            for (int i = 0; i < transpositionVector.Length; i++)
            {
                for (int j = 0; j < matrix.Width; j++)
                {
                    result[j, i] = matrix[j, transpositionVector[i]];
                }
            }

            return new Matrix<T>(result);
        }

        private static bool ValidateTranspositionVector<T>(Matrix<T> matrix, Vector<int> transpositionVector) where T : INumber<T>
        {
            if (matrix.Height != transpositionVector.Length)
            {
                return false;
            }

            var rowsIndexes = new HashSet<int>();
            for (int i = 0; i < transpositionVector.Length; i++)
            {
                int rowIndex = transpositionVector[i];
                if (rowIndex < 0 || rowIndex >= matrix.Height || !rowsIndexes.Add(rowIndex))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
