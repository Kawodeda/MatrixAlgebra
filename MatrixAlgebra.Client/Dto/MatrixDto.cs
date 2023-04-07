using System.Numerics;

namespace MatrixAlgebra.Client.Dto
{
    public class MatrixDto<T> where T : INumber<T>
    {
        public MatrixDto(T[,] elements)
        {
            Elements = elements;
        }

        public MatrixDto(T[] elements)
        {
            Elements = new T[1, elements.Length];
            for (int i = 0; i < elements.Length; i++)
            {
                Elements[0, i] = elements[i];
            }
        }

        public T[,] Elements { get; }
    }

    public class MatrixDto : MatrixDto<float>
    {
        public MatrixDto(float[,] elements)
            : base(elements) { }
    }
}
