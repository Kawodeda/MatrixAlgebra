using MatrixAlgebra.Client.Dto;

namespace MatrixAlgebra.Client.MatrixOperations
{
    public interface IMatrixOperation
    {
        string Title { get; }

        MatrixDto Perform(IMatrixOperationContext context);
    }
}
