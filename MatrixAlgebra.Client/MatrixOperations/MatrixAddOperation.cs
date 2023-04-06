﻿using MatrixAlgebra.Client.Dto;

namespace MatrixAlgebra.Client.MatrixOperations
{
    public class MatrixAddOperation : BaseMatrixOperation
    {
        public override string Title
        {
            get
            {
                return "Add";
            }
        }

        public override MatrixDto Perform(IMatrixOperationContext context)
        {
            Matrix<float> matrixA = ToModel(context.MatrixA);
            Matrix<float> matrixB = ToModel(context.MatrixB);
            Matrix<float> sum = matrixA.Add(matrixB);

            return ToDto(sum);
        }
    }
}
