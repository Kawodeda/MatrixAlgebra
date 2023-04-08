using MatrixAlgebra.Client.ViewModels;

namespace MatrixAlgebra.Client.MatrixOperations.ViewStates
{
    public class SwapRowsOperationState : IMainViewState
    {
        public bool ShowMatrixB { get; } = false;
        public bool ShowScalar { get; } = false;
        public bool ShowTranspositionVector { get; } = false;
        public bool ShowSwapRows { get; } = true;
        public string MatrixATitle { get; } = "Matrix";
    }
}
