using System.Numerics;

namespace MatrixAlgebra
{
    public class Vector<T> where T : INumber<T>
    {
        private readonly T[] _elements;

        public Vector(T[] elements)
        {
            _elements = elements;
        }

        public T this[int i]
        {
            get
            {
                return _elements[i];
            }
        }

        public int Length
        {
            get
            {
                return _elements.Length;
            }
        }

        public T DotProduct(Vector<T> other)
        {
            if (!SameLength(other))
            {
                throw new ArgumentException("The other Vector was of different length");
            }

            T result = T.AdditiveIdentity;
            for (int i = 0; i < Length; i++)
            {
                result += _elements[i] * other[i];
            }

            return result;
        }

        public bool SameLength(Vector<T> other)
        {
            return Length == other.Length;
        }
    }
}