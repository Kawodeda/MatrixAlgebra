using MatrixAlgebra.Client.Dto;

namespace MatrixAlgebra.Client.MatrixOperations
{
    public interface IMatrixBinaryOperationContext
    {
        MatrixDto MatrixA { get; }

        MatrixDto MatrixB { get; }
    }
}
