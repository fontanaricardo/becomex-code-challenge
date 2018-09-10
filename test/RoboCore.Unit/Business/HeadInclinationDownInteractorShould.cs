using RoboCore.Business;
using RoboCore.Business.HeadBusiness;
using RoboCore.Models;
using Xunit;

namespace RoboCore.Unit.Business
{
    public class HeadInclinationDownInteractorShould
    {
        private readonly IRequestHandler<HeadInclinationDownRequest, HeadInclinationDownResponse> _interactor;
        private readonly Robot _robot;

        public HeadInclinationDownInteractorShould()
        {
            _interactor = new HeadInclinationDownInteractor();
            _robot = new Robot();
        }

        [Fact]
        public void NotExceedLimit()
        {
            HeadInclinationDownResponse response = null;

            response = _interactor.Handle(new HeadInclinationDownRequest{
                Head = _robot.Head
            });

            Assert.True(response.IsValid);
            Assert.Equal(InclinationState.Down, _robot.Head.InclinationState);

            response = _interactor.Handle(new HeadInclinationDownRequest{
                Head = _robot.Head
            });

            Assert.False(response.IsValid);
            Assert.Equal(InclinationState.Down, _robot.Head.InclinationState);
        }
    }
}