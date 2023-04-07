using MatrixAlgebra.Client.Dto;
using MatrixAlgebra.Client.MatrixOperations.ViewStates;
using MatrixAlgebra.Client.ViewModels;

namespace MatrixAlgebra.Client.MatrixOperations
{
    public class MatrixTransposeOperation : BaseMatrixOperation
    {
        public override string Title
        {
            get
            {
                return "Transpose";
            }
        }

        public override IMainViewState ViewState { get; } = new UnaryMatrixOperationState();

        public override MatrixDto Perform(IMatrixOperationContext context)
        {
            Matrix<float> matrix = ToModel(context.Matrix);
            Matrix<float> transposed = matrix.Transpose();

            return ToDto(transposed);
        }
    }
}
