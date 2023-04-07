using MatrixAlgebra.Client.Dto;
using MatrixAlgebra.Client.ViewModels;

namespace MatrixAlgebra.Client.MatrixOperations
{
    public abstract class BaseMatrixOperation : IMatrixOperation
    {
        public abstract string Title { get; }

        public abstract IMainViewState ViewState { get; }

        public abstract MatrixDto Perform(IMatrixOperationContext context);

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

        protected Matrix<float> ToModel(MatrixDto matrix)
        {
            return new Matrix<float>(matrix.Elements);
        }
    }
}