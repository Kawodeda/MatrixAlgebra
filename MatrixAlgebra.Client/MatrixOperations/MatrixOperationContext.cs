using MatrixAlgebra.Client.Dto;

namespace MatrixAlgebra.Client.MatrixOperations
{
    public class MatrixOperationContext : IMatrixOperationContext
    {
        public MatrixOperationContext(
            MatrixDto matrix, 
            MatrixDto matrixA, 
            MatrixDto matrixB, 
            float scalar, 
            int row1, 
            int row2, 
            TranspositionVectorDto transpositionVector)
        {
            Matrix = matrix;
            MatrixA = matrixA;
            MatrixB = matrixB;
            Scalar = scalar;
            Row1 = row1;
            Row2 = row2;
            TranspositionVector = transpositionVector;
        }

        public MatrixDto Matrix { get; }

        public MatrixDto MatrixA { get; }

        public MatrixDto MatrixB { get; }

        public float Scalar { get; }

        public int Row1 { get; }

        public int Row2 { get; }

        public TranspositionVectorDto TranspositionVector { get; }
    }
}
