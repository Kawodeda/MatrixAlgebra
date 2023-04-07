using MatrixAlgebra.Client.Dto;
using MatrixAlgebra.Client.MatrixOperations.ViewStates;
using MatrixAlgebra.Client.ViewModels;

namespace MatrixAlgebra.Client.MatrixOperations
{
    public class MatrixScaleOperation : BaseMatrixOperation
    {
        public override string Title
        {
            get
            {
                return "Multiply by scalar";
            }
        }

        public override IMainViewState ViewState { get; } = new ScalarMatrixOperationState();

        public override bool CanPerform(IMatrixOperationContext context)
        {
            return true;
        }

        public override MatrixDto Perform(IMatrixOperationContext context)
        {
            Matrix<float> matrix = ToModel(context.Matrix);
            Matrix<float> scaledMatrix = matrix.Multiply(context.Scalar);

            return ToDto(scaledMatrix);
        }
    }
}
