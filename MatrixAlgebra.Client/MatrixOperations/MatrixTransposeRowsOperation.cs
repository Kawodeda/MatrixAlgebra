using MatrixAlgebra.Client.Dto;
using MatrixAlgebra.Client.MatrixOperations.ViewStates;
using MatrixAlgebra.Client.ViewModels;
using System.Collections.Generic;

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

        public override bool CanPerform(IMatrixOperationContext context)
        {
            return IsTranspositionVector(context.TranspositionVector, context.Matrix);
        }

        public override MatrixDto Perform(IMatrixOperationContext context)
        {
            Matrix<float> matrix = ToModel(context.Matrix);
            Vector<int> transpositionVector = ToModel(context.TranspositionVector);
            Matrix<float> result = MatrixMath.TransposeRows(matrix, transpositionVector);

            return ToDto(result);
        }

        private bool IsTranspositionVector(TranspositionVectorDto transpositionVector, MatrixDto matrix)
        {
            ISet<int> indexes = new HashSet<int>();
            foreach(int index in transpositionVector.Elements)
            {
                if (!indexes.Add(index) || !IsRowIndex(index, matrix))
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsRowIndex(int index, MatrixDto matrix)
        {
            Matrix<float> matrixModel = ToModel(matrix);

            return index >= 0 && index < matrixModel.Height;
        }

        private Vector<int> ToModel(TranspositionVectorDto vector)
        {
            return new Vector<int>(vector.Elements);
        }
    }
}
