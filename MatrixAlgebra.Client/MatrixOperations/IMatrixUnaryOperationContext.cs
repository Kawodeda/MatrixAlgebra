using MatrixAlgebra.Client.Dto;

namespace MatrixAlgebra.Client.MatrixOperations
{
    public interface IMatrixUnaryOperationContext
    {
        MatrixDto Matrix { get; }
    }
}
