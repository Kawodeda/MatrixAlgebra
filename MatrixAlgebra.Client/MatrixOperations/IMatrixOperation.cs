using MatrixAlgebra.Client.Dto;
using MatrixAlgebra.Client.ViewModels;

namespace MatrixAlgebra.Client.MatrixOperations
{
    public interface IMatrixOperation
    {
        string Title { get; }

        IMainViewState ViewState { get; }

        MatrixDto Perform(IMatrixOperationContext context);
    }
}
