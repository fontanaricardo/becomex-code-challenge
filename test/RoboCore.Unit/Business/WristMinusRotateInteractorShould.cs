using RoboCore.Business;
using RoboCore.Business.WristBusiness;
using RoboCore.Models;
using Xunit;

namespace RoboCore.Unit.Business
{
    public class WristMinusRotateInteractorShould
    {
        private readonly IRequestHandler<WristMinusRotateRequest, WristMinusRotateResponse> _interactor;
        private readonly Robot _robot;

        public WristMinusRotateInteractorShould()
        {
            _interactor = new WristMinusRotateInteractor();
            _robot = new Robot();
            _robot.LeftArm.Elbow.Contract();
            _robot.LeftArm.Elbow.Contract();
            _robot.LeftArm.Elbow.Contract();
        }

        [Fact]
        public void ValidIfLimitNotExceeded()
        {
            var response = _interactor.Handle(new WristMinusRotateRequest
            {
                Arm = _robot.LeftArm
            });

            Assert.Equal(_robot.LeftArm.Wrist.Rotate, -45);
            Assert.True(response.IsValid);

            response = _interactor.Handle(new WristMinusRotateRequest
            {
                Arm = _robot.LeftArm
            });

            Assert.Equal(_robot.LeftArm.Wrist.Rotate, -90);
            Assert.True(response.IsValid);
        }

        [Fact]
        public void NotExceedLimit()
        {
            var response = _interactor.Handle(new WristMinusRotateRequest
            {
                Arm = _robot.LeftArm
            });

            for (int i = 0; i < 2; i++)
            {
                response = _interactor.Handle(new WristMinusRotateRequest
                {
                    Arm = _robot.LeftArm
                });
            }

            Assert.Equal(-90, _robot.LeftArm.Wrist.Rotate);
            Assert.False(response.IsValid);
        }

        [Fact]
        public void NotRotateIfElbowRelaxed()
        {
            _robot.LeftArm.Elbow.Relax();

            var response = _interactor.Handle(new WristMinusRotateRequest
            {
                Arm = _robot.LeftArm
            });

            Assert.Equal(0, _robot.LeftArm.Wrist.Rotate);
            Assert.False(response.IsValid);

            _robot.LeftArm.Elbow.Relax();

            response = _interactor.Handle(new WristMinusRotateRequest
            {
                Arm = _robot.LeftArm
            });

            Assert.Equal(0, _robot.LeftArm.Wrist.Rotate);
            Assert.False(response.IsValid);
        }
    }
}