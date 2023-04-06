namespace MatrixAlgebra.Client.Dto
{
    public class VectorDto
    {
        public float[] Elements { get; private set; }

        public VectorDto(float[] elements)
        {
            Elements = elements;
        }
    }
}
