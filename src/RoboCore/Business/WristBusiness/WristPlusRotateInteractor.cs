using System.Threading.Tasks;
using FluentValidation.Results;
using RoboCore.Models;

namespace RoboCore.Business.WristBusiness
{
    public class WristPlusRotateInteractor : IRequestHandler<WristPlusRotateRequest, WristPlusRotateResponse>
    {
        private const int MaxLimit = 180;

        public WristPlusRotateResponse Handle (WristPlusRotateRequest request)
        {
            var response = new WristPlusRotateResponse ();

            if (request.Arm.Wrist.Rotate == MaxLimit)
            {
                response.AddError(
                    propertyName: nameof(request.Arm.Wrist.Rotate),
                    errorMessage: "Rotate max limit reached.");

                return response;
            }

            if (request.Arm.Elbow.ElbowState != ElbowState.HeavilyContracted)
            {
                response.AddError(
                    propertyName: nameof(request.Arm.Wrist.Rotate),
                    errorMessage: "Cannot rotate wrist if elbow is not heavily contracted.");

                return response;
            }

            request.Arm.Wrist.PlusRotate();
            return response;
        }
    }
}