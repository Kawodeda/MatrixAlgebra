﻿using MatrixAlgebra.Client.Dto;
using MatrixAlgebra.Client.MatrixOperations.ViewStates;
using MatrixAlgebra.Client.ViewModels;

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

        public override IMainViewState ViewState { get; } = new BinaryMatrixOperationState();

        public override bool CanPerform(IMatrixOperationContext context)
        {
            Matrix<float> matrixA = ToModel(context.MatrixA);
            Matrix<float> matrixB = ToModel(context.MatrixB);

            return matrixA.Width == matrixB.Width
                && matrixA.Height == matrixB.Height;
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
