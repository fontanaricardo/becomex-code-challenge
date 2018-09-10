using RoboCore.Models;

namespace RoboCore.Business.HeadBusiness
{
    public class HeadRotatePlusInteractor : IRequestHandler<HeadRotatePlusRequest, HeadRotatePlusResponse>
    {
        public HeadRotatePlusResponse Handle(HeadRotatePlusRequest request)
        {
            var response = new HeadRotatePlusResponse();

            if (request.Head.Rotate == 90)
            {
                response.AddError(
                    propertyName: nameof(request.Head.Rotate),
                    errorMessage: "Max value reached");

                return response;
            }

            if (request.Head.InclinationState == InclinationState.Down)
            {
                response.AddError(
                    propertyName: nameof(request.Head.Rotate),
                    errorMessage: "Cannot rotate head if inclination is down"
                );

                return response;
            }

            request.Head.PlusRotate();

            return response;
        }
    }
}