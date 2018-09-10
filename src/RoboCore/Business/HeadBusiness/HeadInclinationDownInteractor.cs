using RoboCore.Models;

namespace RoboCore.Business.HeadBusiness
{
    public class HeadInclinationDownInteractor : IRequestHandler<HeadInclinationDownRequest, HeadInclinationDownResponse>
    {
        public HeadInclinationDownResponse Handle(HeadInclinationDownRequest request)
        {
            var response = new HeadInclinationDownResponse();

            if (request.Head.InclinationState == InclinationState.Down)
            {
                response.AddError(
                    propertyName: nameof(request.Head.InclinationState),
                    errorMessage: "Min value reached.");

                return response;
            }

            request.Head.InclinationDown();

            return response;
        }
    }
}