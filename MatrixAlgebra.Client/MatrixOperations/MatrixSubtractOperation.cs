using MatrixAlgebra.Client.Dto;

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

        public override MatrixDto Perform(IMatrixOperationContext context)
        {
            Matrix<float> matrixA = ToModel(context.MatrixA);
            Matrix<float> matrixB = ToModel(context.MatrixB);
            Matrix<float> difference = matrixA.Subtract(matrixB);

            return ToDto(difference);
        }
    }
}
