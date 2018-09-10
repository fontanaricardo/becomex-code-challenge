using RoboCore.Models;

namespace RoboCore.Business.HeadBusiness
{
    public class HeadInclinationUpInteractor : IRequestHandler<HeadInclinationUpRequest, HeadInclinationUpResponse>
    {
        public HeadInclinationUpResponse Handle(HeadInclinationUpRequest request)
        {
            var response = new HeadInclinationUpResponse();

            if (request.Head.InclinationState == InclinationState.Up)
            {
                response.AddError(
                    propertyName: nameof(request.Head.InclinationState),
                    errorMessage: "Max value reached.");

                return response;
            }

            request.Head.InclinationUp();

            return response;
        }
    }
}