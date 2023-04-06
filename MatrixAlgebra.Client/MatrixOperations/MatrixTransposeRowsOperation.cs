using MatrixAlgebra.Client.Dto;

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
