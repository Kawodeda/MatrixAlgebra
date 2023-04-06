using MatrixAlgebra.Client.Dto;

namespace MatrixAlgebra.Client.MatrixOperations
{
    public interface IMatrixOperationContext
    {
        MatrixDto Matrix { get; }

        MatrixDto MatrixA { get; }

        MatrixDto MatrixB { get; }
    }
}
