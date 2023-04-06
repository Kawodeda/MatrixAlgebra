using MatrixAlgebra.Client.Dto;

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

        public override MatrixDto Perform(IMatrixOperationContext context)
        {
            Matrix<float> matrix = ToModel(context.Matrix);
            Matrix<float> scaledMatrix = matrix.Multiply(context.Scalar);

            return ToDto(scaledMatrix);
        }
    }
}
