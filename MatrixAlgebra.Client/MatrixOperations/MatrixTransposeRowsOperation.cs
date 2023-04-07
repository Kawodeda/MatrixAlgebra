using MatrixAlgebra.Client.Dto;
using MatrixAlgebra.Client.MatrixOperations.ViewStates;
using MatrixAlgebra.Client.ViewModels;

namespace MatrixAlgebra.Client.MatrixOperations
{
    public class MatrixTransposeRowsOperation : BaseMatrixOperation
    {
        public override string Title
        {
            get
            {
                return "Transpose rows";
            }
        }

        public override IMainViewState ViewState { get; } = new MatrixTransposeRowsOperationState();

        public override MatrixDto Perform(IMatrixOperationContext context)
        {
            Matrix<float> matrix = ToModel(context.Matrix);
            Vector<int> transpositionVector = ToModel(context.TranspositionVector);
            Matrix<float> result = MatrixMath.TransposeRows(matrix, transpositionVector);

            return ToDto(result);
        }

        private Vector<int> ToModel(TranspositionVectorDto vector)
        {
            return new Vector<int>(vector.Elements);
        }
    }
}
