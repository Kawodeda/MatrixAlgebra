using MatrixAlgebra.Client.Dto;

namespace MatrixAlgebra.Client.MatrixOperations
{
    public interface IMatrixOperationContext
    {
        MatrixDto Matrix { get; }

        MatrixDto MatrixA { get; }

        MatrixDto MatrixB { get; }

        float Scalar { get; }

        int Row1 { get; }

        int Row2 { get; }

        TranspositionVectorDto TranspositionVector { get; }
    }
}
