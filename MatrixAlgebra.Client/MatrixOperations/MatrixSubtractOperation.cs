using MatrixAlgebra.Client.Dto;
using MatrixAlgebra.Client.MatrixOperations.ViewStates;
using MatrixAlgebra.Client.ViewModels;

namespace MatrixAlgebra.Client.MatrixOperations
{
    public class MatrixSubtractOperation : BaseMatrixOperation
    {
        public override string Title
        {
            get
            {
                return "Subtract";
            }
        }

        public override IMainViewState ViewState { get; } = new BinaryMatrixOperationState();

        public override MatrixDto Perform(IMatrixOperationContext context)
        {
            Matrix<float> matrixA = ToModel(context.MatrixA);
            Matrix<float> matrixB = ToModel(context.MatrixB);
            Matrix<float> difference = matrixA.Subtract(matrixB);

            return ToDto(difference);
        }
    }
}
