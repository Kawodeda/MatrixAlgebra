namespace MatrixAlgebra.Client.Dto
{
    public class MatrixDto
    {
        public MatrixDto(float[,] elements)
        {
            Elements = elements;
        }

        public float[,] Elements { get; }
    }
}
