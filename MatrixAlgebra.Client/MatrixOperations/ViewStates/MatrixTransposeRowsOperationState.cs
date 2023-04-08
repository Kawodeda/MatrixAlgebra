using MatrixAlgebra.Client.ViewModels;

namespace MatrixAlgebra.Client.MatrixOperations.ViewStates
{
    public class MatrixTransposeRowsOperationState : IMainViewState
    {
        public bool ShowMatrixB { get; } = false;
        public bool ShowScalar { get; } = false;
        public bool ShowTranspositionVector { get; } = true;
        public bool ShowSwapRows { get; } = false;
        public string MatrixATitle { get; } = "Matrx";
    }
}
