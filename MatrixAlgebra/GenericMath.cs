using System.Numerics;

namespace MatrixAlgebra
{
    public static class GenericMath
    {
        public static T Pow<T>(T x, int y) where T : INumber<T>
        {
            if (y == 0)
            {
                return T.One;
            }

            T monomial = GetPowerMonomial(x, y);
            T result = monomial;
            for (int i = 1; i < y; i++)
            {
                result *= monomial;
            }

            return result;
        }

        public static bool NearlyEquals<T>(T a, T b, T epsilon) where T : INumber<T>
        {
            T diff = T.Abs(a - b);
            
            return diff < epsilon;
        }

        private static T GetPowerMonomial<T>(T x, int y) where T : INumber<T>
        {
            return int.IsNegative(y) 
                ? T.One / x 
                : x;
        }
    }
}
