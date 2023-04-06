using MatrixAlgebra.Client.Dto;

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

        public override MatrixDto Perform(IMatrixOperationContext context)
        {
            var matrix = new SquareMatrix<float>(ToModel(context.Matrix));
            SquareMatrix<float> inverse = matrix.Inverse();

            return ToDto(inverse.Matrix);
        }
    }
}
