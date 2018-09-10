using RoboCore.Models;

namespace RoboCore.Business.ElbowBusiness
{
    public class ElbowContractInteractor : IRequestHandler<ElbowContractRequest, ElbowContractResponse>
    {
        public ElbowContractResponse Handle (ElbowContractRequest request)
        {
            var response = new ElbowContractResponse ();

            if (request.Arm.Elbow.ElbowState == ElbowState.HeavilyContracted)
            {
                response.AddError(
                    propertyName: nameof(request.Arm.Wrist.Rotate),
                    errorMessage: "Max limit reached.");

                return response;
            }

            request.Arm.Elbow.Contract ();
            return response;
        }
    }
}