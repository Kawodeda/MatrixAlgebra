using MatrixAlgebra.Client.ViewModels;

namespace MatrixAlgebra.Client.MatrixOperations.ViewStates
{
    public class ScalarMatrixOperationState : IMainViewState
    {
        public bool ShowMatrixB { get; } = false;
        public bool ShowScalar { get; } = true;
        public bool ShowTranspositionVector { get; } = false;
        public bool ShowSwapRows { get; } = false;
        public string MatrixATitle { get; } = "Matrix";
    }
}
