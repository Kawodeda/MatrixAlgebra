using MatrixAlgebra.Client.Dto;
using MatrixAlgebra.Client.MatrixOperations.ViewStates;
using MatrixAlgebra.Client.ViewModels;

namespace MatrixAlgebra.Client.MatrixOperations
{
    public class MatrixInverseOperation : BaseMatrixOperation
    {
        public override string Title
        {
            get
            {
                return "Inverse";
            }
        }

        public override IMainViewState ViewState { get; } = new UnaryMatrixOperationState();

        public override MatrixDto Perform(IMatrixOperationContext context)
        {
            var matrix = new SquareMatrix<float>(ToModel(context.Matrix));
            SquareMatrix<float> inverse = matrix.Inverse();

            return ToDto(inverse.Matrix);
        }
    }
}
