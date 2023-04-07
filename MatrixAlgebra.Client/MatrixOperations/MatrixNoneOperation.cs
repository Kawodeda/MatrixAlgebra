using MatrixAlgebra.Client.Dto;
using MatrixAlgebra.Client.MatrixOperations.ViewStates;
using MatrixAlgebra.Client.ViewModels;
using System;

namespace MatrixAlgebra.Client.MatrixOperations
{
    public class MatrixNoneOperation : BaseMatrixOperation
    {
        public override string Title { get; } = "--- select operation ---";
        public override IMainViewState ViewState { get; } = new NoneOperationState();

        public override bool CanPerform(IMatrixOperationContext context)
        {
            return false;
        }

        public override MatrixDto Perform(IMatrixOperationContext context)
        {
            throw new NotImplementedException();
        }
    }
}
