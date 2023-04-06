using MatrixAlgebra.Client.Dto;

namespace MatrixAlgebra.Client.MatrixOperations
{
    public class MatrixAddOperation : IMatrixOperation
    {
        public string Title
        {
            get
            {
                return "Add";
            }
        }

        public MatrixDto Perform(IMatrixOperationContext context)
        {
            Matrix<float> matrixA = ToModel(context.MatrixA);
            Matrix<float> matrixB = ToModel(context.MatrixB);
            Matrix<float> sum = matrixA.Add(matrixB);

            return ToDto(sum);
        }

        protected Matrix<float> ToModel(MatrixDto matrix)
        {
            return new Matrix<float>(matrix.Elements);
        }

        protected MatrixDto ToDto(Matrix<float> matrix)
        {
            var result = new float[matrix.Width, matrix.Height];
            for (int i = 0; i < matrix.Width; i++)
            {
                for (int j = 0; j < matrix.Height; j++)
                {
                    result[i, j] = matrix[i, j];
                }
            }

            return new MatrixDto(result);
        }
    }
}
