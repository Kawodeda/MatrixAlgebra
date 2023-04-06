namespace MatrixAlgebra.Client.Dto
{
    public class TranspositionVectorDto
    {
        public TranspositionVectorDto(int[] elements)
        {
            Elements = elements;
        }

        public int[] Elements { get; }
    }
}
