using MatrixAlgebra;

namespace MatrixAlgebraTests
{
    public class SquareMatrixTests
    {
        private const float Epsilon = 0.000001f;

        private static readonly object[] _inverseCases = new object[]
        {
            new SquareMatrix<float>(new float[2, 2] { { 1, 3 }, { 2, 4 } }),
            new SquareMatrix<float>(new float[3, 3] { { 4, 0, 0 }, { 0, 4, 0 }, { 20, -5.5f, 1 } }),
            new SquareMatrix<float>(new float[3, 3] { { 2.1f, 6.8f, 5.5f }, { -0.2f, -8.1f, 4.9f }, { -2.7f, -2.3f, -9.7f } }),
            new SquareMatrix<float>(new float[4, 4] { { -7, -4, 7, 9 }, { 9, -3, 3, 1 }, { 4, 8, 0, 6 }, { -6, -4, -8, -1 } })
        };

        [Test]
        [TestCaseSource(nameof(_inverseCases))]
        public void For_Inverse_Expect_ResultMultipliedByOriginalIsIdentity(SquareMatrix<float> matrix)
        {
            SquareMatrix<float> inverse = matrix.Inverse();
            SquareMatrix<float> actualIdentity = inverse.Multiply(matrix);
            var expectedIdentity = SquareMatrix<float>.CreateIdentity(matrix.Size);

            Assert.That(expectedIdentity.Equals(actualIdentity, Epsilon), Is.True);
        }
    }
}
