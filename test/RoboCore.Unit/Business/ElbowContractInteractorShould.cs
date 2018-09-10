using RoboCore.Business;
using RoboCore.Business.ElbowBusiness;
using RoboCore.Models;
using Xunit;

namespace RoboCore.Unit.Business
{
    public class ElbowContractInteractorShould
    {
        private readonly IRequestHandler<ElbowContractRequest, ElbowContractResponse> _interactor;
        private readonly Robot _robot;

        public ElbowContractInteractorShould()
        {
            _interactor = new ElbowContractInteractor();
            _robot = new Robot();
        }

        [Fact]
        public void NotExceedLimit()
        {
            ElbowContractResponse response = null;

            for (int i = 0; i < 3; i++)
            {
                response = _interactor.Handle(new ElbowContractRequest{
                    Arm = _robot.LeftArm
                });
            }

            Assert.True(response.IsValid);
            Assert.Equal(ElbowState.HeavilyContracted, _robot.LeftArm.Elbow.ElbowState);

            response = _interactor.Handle(new ElbowContractRequest{
                Arm = _robot.LeftArm
            });

            Assert.False(response.IsValid);
            Assert.Equal(ElbowState.HeavilyContracted, _robot.LeftArm.Elbow.ElbowState);
        }
    }
}