namespace MatrixAlgebra.Client.ViewModels
{
    public interface IMainViewState
    {
        bool ShowMatrixB { get; }

        bool ShowScalar { get; }

        bool ShowTranspositionVector { get; }

        bool ShowSwapRows { get; }

        string MatrixATitle { get; }
    }
}
