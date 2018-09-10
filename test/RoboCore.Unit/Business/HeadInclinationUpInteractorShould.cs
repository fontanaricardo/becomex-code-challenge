using RoboCore.Business;
using RoboCore.Business.HeadBusiness;
using RoboCore.Models;
using Xunit;

namespace RoboCore.Unit.Business
{
    public class HeadInclinationUpInteractorShould
    {
        private readonly IRequestHandler<HeadInclinationUpRequest, HeadInclinationUpResponse> _interactor;
        private readonly Robot _robot;

        public HeadInclinationUpInteractorShould()
        {
            _interactor = new HeadInclinationUpInteractor();
            _robot = new Robot();
        }

        [Fact]
        public void NotExceedLimit()
        {
            HeadInclinationUpResponse response = null;

            response = _interactor.Handle(new HeadInclinationUpRequest{
                Head = _robot.Head
            });

            Assert.True(response.IsValid);
            Assert.Equal(InclinationState.Up, _robot.Head.InclinationState);

            response = _interactor.Handle(new HeadInclinationUpRequest{
                Head = _robot.Head
            });

            Assert.False(response.IsValid);
            Assert.Equal(InclinationState.Up, _robot.Head.InclinationState);
        }
    }
}