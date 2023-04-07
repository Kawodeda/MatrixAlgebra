using MatrixAlgebra.Client.Dto;
using MatrixAlgebra.Client.MatrixOperations.ViewStates;
using MatrixAlgebra.Client.ViewModels;

namespace MatrixAlgebra.Client.MatrixOperations
{
    public class MatrixSwapRowsOperation : BaseMatrixOperation
    {
        public override string Title
        {
            get
            {
                return "Swap two rows";
            }
        }

        public override IMainViewState ViewState { get; } = new SwapRowsOperationState();

        public override MatrixDto Perform(IMatrixOperationContext context)
        {
            Matrix<float> matrix = ToModel(context.Matrix);
            Vector<int> swapTwoRows = GetTranspositionVector(matrix, context.Row1, context.Row2);
            Matrix<float> result = MatrixMath.TransposeRows(matrix, swapTwoRows);

            return ToDto(result);
        }

        private Vector<int> GetTranspositionVector(Matrix<float> matrix, int row1, int row2)
        {
            var result = new int[matrix.Height];
            for (int i = 0; i < matrix.Height; i++)
            {
                if (i == row1)
                {
                    result[i] = row2;
                }
                else if (i == row2)
                {
                    result[i] = row1;
                }
                else
                {
                    result[i] = i;
                }
            }

            return new Vector<int>(result);
        }
    }
}
