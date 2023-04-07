using MatrixAlgebra.Client.Dto;
using MatrixAlgebra.Client.ViewModels;

namespace MatrixAlgebra.Client.MatrixOperations
{
    public interface IMatrixOperation
    {
        string Title { get; }

        IMainViewState ViewState { get; }

        bool CanPerform(IMatrixOperationContext context);

        MatrixDto Perform(IMatrixOperationContext context);
    }
}
