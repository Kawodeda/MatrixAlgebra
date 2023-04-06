using MatrixAlgebra.Client.Dto;

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

        public override MatrixDto Perform(IMatrixOperationContext context)
        {
            Matrix<float> matrix = ToModel(context.Matrix);
            Matrix<float> result = matrix.Multiply(matrix.Transpose());

            return ToDto(result);
        }
    }
}
