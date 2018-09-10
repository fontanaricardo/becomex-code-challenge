using FluentValidation.Results;
using RoboCore.Models;

namespace RoboCore.Business.WristBusiness
{
    public class WristMinusRotateInteractor : IRequestHandler<WristMinusRotateRequest, WristMinusRotateResponse>
    {
        public WristMinusRotateResponse Handle(WristMinusRotateRequest request)
        {
            var response = new WristMinusRotateResponse();

            if (request.Arm.Wrist.Rotate == -90)
            {
                response.AddError(
                    propertyName: nameof(request.Arm.Wrist.Rotate),
                    errorMessage: "Rotate min limit reached.");

                return response;
            }

            if (request.Arm.Elbow.ElbowState != ElbowState.HeavilyContracted)
            {
                response.AddError(
                    propertyName: nameof(request.Arm.Wrist.Rotate),
                    errorMessage: "Cannot rotate wrist if elbow is not heavily contracted.");

                return response;
            }

            request.Arm.Wrist.MinusRotate();

            return response;
        }
    }
}