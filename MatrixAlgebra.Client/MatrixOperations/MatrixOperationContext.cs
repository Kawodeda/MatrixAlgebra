using MatrixAlgebra.Client.Dto;

namespace MatrixAlgebra.Client.MatrixOperations
{
    public class MatrixOperationContext : IMatrixOperationContext
    {
        public MatrixOperationContext(MatrixDto matrix, MatrixDto matrixA, MatrixDto matrixB)
        {
            Matrix = matrix;
            MatrixA = matrixA;
            MatrixB = matrixB;
        }

        public MatrixDto Matrix { get; }
        public MatrixDto MatrixA { get; }
        public MatrixDto MatrixB { get; }
    }
}
