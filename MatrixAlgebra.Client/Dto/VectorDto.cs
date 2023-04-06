namespace MatrixAlgebra.Client.Dto
{
    public class VectorDto
    {
        public VectorDto(float[] elements)
        {
            Elements = elements;
        }

        public float[] Elements { get; }
    }
}
