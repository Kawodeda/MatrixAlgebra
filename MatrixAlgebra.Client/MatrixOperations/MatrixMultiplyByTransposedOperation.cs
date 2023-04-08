using MatrixAlgebra.Client.Dto;
using MatrixAlgebra.Client.MatrixOperations.ViewStates;
using MatrixAlgebra.Client.ViewModels;

namespace MatrixAlgebra.Client.MatrixOperations
{
    public class MatrixMultiplyByTransposedOperation : BaseMatrixOperation
    {
        public override string Title
        {
            get
            {
                return "Multiply by transposed matrix";
            }
        }

        public override IMainViewState ViewState { get; } = new UnaryMatrixOperationState();

        public override bool CanPerform(IMatrixOperationContext context)
        {
            return true;
        }

        public override MatrixDto Perform(IMatrixOperationContext context)
        {
            Matrix<float> matrix = ToModel(context.Matrix);
            Matrix<float> result = matrix.Multiply(matrix.Transpose());

            return ToDto(result);
        }
    }
}
