using RoboCore.Models;

namespace RoboCore.Business.ElbowBusiness
{
    public class ElbowRelaxInteractor : IRequestHandler<ElbowRelaxRequest, ElbowRelaxResponse>
    {
        public ElbowRelaxResponse Handle(ElbowRelaxRequest request)
        {
            var response = new ElbowRelaxResponse();

            if (request.Arm.Elbow.ElbowState == ElbowState.InRest)
            {
                response.AddError(
                    propertyName: nameof(request.Arm.Wrist.Rotate),
                    errorMessage: "Min limit reached.");

                return response;
            }

            request.Arm.Elbow.Relax();
            return response;
        }
    }
}