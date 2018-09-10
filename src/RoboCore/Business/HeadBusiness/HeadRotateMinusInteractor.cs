using RoboCore.Models;

namespace RoboCore.Business.HeadBusiness
{
    public class HeadRotateMinusInteractor : IRequestHandler<HeadRotateMinusRequest, HeadRotateMinusResponse>
    {
        public HeadRotateMinusResponse Handle(HeadRotateMinusRequest request)
        {
            var response = new HeadRotateMinusResponse();

            if (request.Head.Rotate == -90)
            {
                response.AddError(
                    propertyName: nameof(request.Head.Rotate),
                    errorMessage: "Min value reached"
                );

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

            request.Head.MinusRotate();

            return response;
        }
    }
}