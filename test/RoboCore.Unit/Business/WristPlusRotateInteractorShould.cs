using RoboCore.Business;
using RoboCore.Business.WristBusiness;
using RoboCore.Models;
using Xunit;

namespace RoboCore.Unit.Business
{
    public class WristPlusRotateInteractorShould
    {
        private readonly IRequestHandler<WristPlusRotateRequest, WristPlusRotateResponse> _interactor;
        private readonly Robot _robot;

        public WristPlusRotateInteractorShould()
        {
            _interactor = new WristPlusRotateInteractor();
            _robot = new Robot();
            _robot.RightArm.Elbow.Contract();
            _robot.RightArm.Elbow.Contract();
            _robot.RightArm.Elbow.Contract();
        }

        [Fact]
        public void ValidIfLimitNotExceeded()
        {
            int increment = 45;

            for (int i = 0; i < 4; i++)
            {
                var response = _interactor.Handle(new WristPlusRotateRequest
                {
                    Arm = _robot.RightArm
                });

                Assert.Equal(increment, _robot.RightArm.Wrist.Rotate);
                Assert.True(response.IsValid);
                increment += 45;
            }
        }

        [Fact]
        public void NotExceedLimit()
        {
            WristPlusRotateResponse response = null;

            for (int i = 0; i < 6; i++)
            {
                response = _interactor.Handle(new WristPlusRotateRequest
                {
                    Arm = _robot.RightArm
                });
            }

            Assert.Equal(180, _robot.RightArm.Wrist.Rotate);
            Assert.False(response.IsValid);
        }

        [Fact]
        public void NotRotateIfElbowRelaxed()
        {
            _robot.RightArm.Elbow.Relax();

            var response = _interactor.Handle(new WristPlusRotateRequest
            {
                Arm = _robot.RightArm
            });

            Assert.Equal(0, _robot.RightArm.Wrist.Rotate);
            Assert.False(response.IsValid);

            _robot.RightArm.Elbow.Relax();

            response = _interactor.Handle(new WristPlusRotateRequest
            {
                Arm = _robot.RightArm
            });

            Assert.Equal(0, _robot.RightArm.Wrist.Rotate);
            Assert.False(response.IsValid);
        }
    }
}