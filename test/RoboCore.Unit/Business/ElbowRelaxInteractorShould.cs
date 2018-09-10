using RoboCore.Business;
using RoboCore.Business.ElbowBusiness;
using RoboCore.Models;
using Xunit;

namespace RoboCore.Unit.Business
{
    public class ElbowRelaxInteractorShould
    {
        private readonly IRequestHandler<ElbowRelaxRequest, ElbowRelaxResponse> _interactor;
        private readonly Robot _robot;

        public ElbowRelaxInteractorShould()
        {
            _interactor = new ElbowRelaxInteractor();
            _robot = new Robot();
        }

        [Fact]
        public void NotExceedLimit()
        {
            ElbowRelaxResponse response = null;

            response = _interactor.Handle(new ElbowRelaxRequest{
                Arm = _robot.LeftArm
            });

            Assert.False(response.IsValid);
            Assert.Equal(ElbowState.InRest, _robot.LeftArm.Elbow.ElbowState);
        }
    }
}