using MatrixAlgebra;

namespace MatrixAlgebraTests
{
    public class MatrixTests
    {
        private const float Epsilon = 0.000001f;

        private static readonly IReadOnlyCollection<object> _addCases = new List<object>
        {
            new object[] 
            { 
                new Matrix<float>(new float[2, 3] { { 0, 0.5f, 1.8f }, { 4, 2.21f, 1 } }),
                new Matrix<float>(new float[2, 3] { { 3.7f, 11, 0.891f }, { 0, 8, 5.5f } }),
                new Matrix<float>(new float[2, 3] { { 3.7f, 11.5f, 2.691f }, { 4, 10.21f, 6.5f } })
            },
            new object[]
            {
                new Matrix<float>(new float[3, 3] { { 1, 0, 3.38f }, { 20.1f, 4.1f, 2 }, { 7.7f, 3.2f, 6 } }),
                new Matrix<float>(new float[3, 3] { { 1, 1, 2 }, { 0, 2, 1 }, { 1, 1, 1 } }),
                new Matrix<float>(new float[3, 3] { { 2, 1, 5.38f }, { 20.1f, 6.1f, 3 }, { 8.7f, 4.2f, 7 } })
            },
            new object[]
            {
                new Matrix<float>(new float[1, 1] { { 2.245f } }),
                new Matrix<float>(new float[1, 1] { { 4.6f } }),
                new Matrix<float>(new float[1, 1] { { 6.845f } })
            }
        };

        private static readonly IReadOnlyCollection<object> _subtractCases = new List<object>
        {
            new object[]
            {
                new Matrix<float>(new float[2, 3] { { 0, 0.5f, 1.8f }, { 4, 2.21f, 1 } }),
                new Matrix<float>(new float[2, 3] { { 3.7f, 11, 0.891f }, { 0, 8, 5.5f } }),
                new Matrix<float>(new float[2, 3] { { -3.7f, -10.5f, 0.909f }, { 4, -5.79f, -4.5f } })
            },
            new object[]
            {
                new Matrix<float>(new float[3, 3] { { 1, 0, 3.38f }, { 20.1f, 4.1f, 2 }, { 7.7f, 3.2f, 6 } }),
                new Matrix<float>(new float[3, 3] { { 1, 1, 2 }, { 0, 2, 1 }, { 1, 1, 1 } }),
                new Matrix<float>(new float[3, 3] { { 0, -1, 1.38f }, { 20.1f, 2.1f, 1 }, { 6.7f, 2.2f, 5 } })
            },
            new object[]
            {
                new Matrix<float>(new float[1, 1] { { 2.245f } }),
                new Matrix<float>(new float[1, 1] { { 4.6f } }),
                new Matrix<float>(new float[1, 1] { { -2.355f } })
            }
        };

        private static readonly IReadOnlyCollection<object> _multiplyByScalarCases = new List<object>
        {
            new object[]
            {
                new Matrix<float>(new float[4, 2] { { 0, 4 }, { 5.8f, 1 }, { 2, 5 }, { 10.8f, 8.1f } }),
                5,
                new Matrix<float>(new float[4, 2] { { 0, 20 }, { 29, 5 }, { 10, 25 }, { 54, 40.5f } })
            },
            new object[]
            {
                new Matrix<float>(new float[2, 2] { { 11.9f, 4.12f }, { 5.8f, 1 } }),
                0,
                new Matrix<float>(new float[2, 2] { { 0, 0 }, { 0, 0 } })
            },
            new object[]
            {
                new Matrix<float>(new float[3, 2] { { 0, 4 }, { 5.8f, 1 }, { -2, 5 } }),
                -1.2f,
                new Matrix<float>(new float[3, 2] { { 0, -4.8f }, { -6.96f, -1.2f }, { 2.4f, -6 } })
            }
        };

        private static readonly IReadOnlyCollection<object> _multiplyByMatrixCases = new List<object>
        {
            new object[]
            {
                new Matrix<float>(new float[3, 3] { { -7.76f, -1.57f, 8.28f }, { 9.99f, -8.22f, -9.33f }, { -9.27f, 4.03f, 9.8f } }),
                new Matrix<float>(new float[3, 3] { { -4.22f, -8.57f, 0.13f }, { -2.24f, -4.97f, -5.2f }, { 3.74f, -8.69f, -0.46f } }),
                new Matrix<float>(new float[3, 3] { { -54.072197f, 77.594696f, 46.2905f }, { 15.9361076f, 23.4142017f, -23.1371f }, { -111.5713f, 63.7061958f, 107.536896f } })
            },
            new object[]
            {
                new Matrix<float>(new float[3, 3] { { -7.76f, 9.99f, -9.27f }, { -1.57f, -8.22f, 4.03f }, { 8.28f, -9.33f, 9.8f } }),
                new Matrix<float>(new float[3, 3] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } }),
                new Matrix<float>(new float[3, 3] { { -7.76f, 9.99f, -9.27f }, { -1.57f, -8.22f, 4.03f }, { 8.28f, -9.33f, 9.8f } })
            },
            new object[]
            {
                new Matrix<float>(new float[3, 3] { { 1, 0, 0 }, { 0, 1, 0 }, { 20f, -5.5f, 1 } }),
                new Matrix<float>(new float[3, 3] { { 3, 0, 0 }, { 0, 3, 0 }, { 0, 0, 1 } }),
                new Matrix<float>(new float[3, 3] { { 3, 0, 0 }, { 0, 3, 0 }, { 20, -5.5f, 1 } })
            }
        };

        private static readonly IReadOnlyCollection<object> _transposeCases = new List<object>
        {
            new object[]
            {
                new Matrix<float>(new float[3, 3] { { -7.76f, -1.57f, 8.28f }, { 9.99f, -8.22f, -9.33f }, { -9.27f, 4.03f, 9.8f } }),
                new Matrix<float>(new float[3, 3] { { -7.76f, 9.99f, -9.27f }, { -1.57f, -8.22f, 4.03f }, { 8.28f, -9.33f, 9.8f } })
            },
            new object[]
            {
                new Matrix<float>(new float[3, 2] { { -10, 1 }, { 5.6f, 7.89f }, { 0, -11 } }),
                new Matrix<float>(new float[2, 3] { { -10, 5.6f, 0 }, { 1, 7.89f, -11 } })
            },
            new object[]
            {
                new Matrix<float>(new float[4, 1] { { -9.01f }, { 8.79f }, { -11 }, { 20.1f } }),
                new Matrix<float>(new float[1, 4] { { -9.01f, 8.79f, -11, 20.1f } })
            }
        };

        [Test]
        [TestCaseSource(nameof(_addCases))]
        public void For_Add_Expect_ResultIsTheSumOfMatrices(Matrix<float> a, Matrix<float> b, Matrix<float> expected)
        {
            Matrix<float> actual = a.Add(b);

            Assert.That(expected.Equals(actual, Epsilon), Is.True);
        }

        [Test]
        [TestCaseSource(nameof(_subtractCases))]
        public void For_Subtract_Expect_ResultIsTheDifferenceOfMatrices(Matrix<float> a, Matrix<float> b, Matrix<float> expected)
        {
            Matrix<float> actual = a.Subtract(b);

            Assert.That(expected.Equals(actual, Epsilon), Is.True);
        }

        [Test]
        [TestCaseSource(nameof(_multiplyByScalarCases))]
        public void For_MultiplyByScalar_Expect_ResultIsTheScaledMatrix(Matrix<float> matrix, float scalar, Matrix<float> expected)
        {
            Matrix<float> actual = matrix.Multiply(scalar);

            Assert.That(expected.Equals(actual, Epsilon), Is.True);
        }

        [Test]
        [TestCaseSource(nameof(_multiplyByMatrixCases))]
        public void For_MultiplyByMatrix_Expect_ResultIsTheProductOfMatrices(Matrix<float> a, Matrix<float> b, Matrix<float> expected)
        {
            Matrix<float> actual = a.Multiply(b);

            Assert.That(expected.Equals(actual, Epsilon), Is.True);
        }

        [Test]
        [TestCaseSource(nameof(_transposeCases))]
        public void For_Transpose_Expect_ResultIsTransposedMatrix(Matrix<float> matrix, Matrix<float> expected)
        {
            Matrix<float> actual = matrix.Transpose();

            Assert.That(expected.Equals(actual, Epsilon), Is.True);
        }
    }
}