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

            T result = GetPowerMonomial(x, y);
            for (int i = 1; i <= y; i++)
            {
                result *= result;
            }

            return result;
        }

        private static T GetPowerMonomial<T>(T x, int y) where T : INumber<T>
        {
            return int.IsNegative(y) 
                ? T.One / x 
                : x;
        }
    }
}
