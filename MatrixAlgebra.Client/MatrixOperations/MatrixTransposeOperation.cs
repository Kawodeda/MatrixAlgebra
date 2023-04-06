using MatrixAlgebra.Client.Dto;

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

        public override MatrixDto Perform(IMatrixOperationContext context)
        {
            Matrix<float> matrix = ToModel(context.Matrix);
            Matrix<float> transposed = matrix.Transpose();

            return ToDto(transposed);
        }
    }
}
