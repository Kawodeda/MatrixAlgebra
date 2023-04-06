namespace MatrixAlgebra.Client.Dto
{
    public class MatrixDto
    {
        public float[,] Elements { get; set; }

        public MatrixDto(float[,] elements)
        {
            Elements = elements;
        }
    }
}
