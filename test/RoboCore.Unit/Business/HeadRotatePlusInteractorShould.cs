using RoboCore.Business;
using RoboCore.Business.HeadBusiness;
using RoboCore.Models;
using Xunit;

namespace RoboCore.Unit.Business
{
    public class HeadRotatePlusInteractorShould
    {
        private readonly IRequestHandler<HeadRotatePlusRequest, HeadRotatePlusResponse> _interactor;
        private readonly Robot _robot;

        public HeadRotatePlusInteractorShould()
        {
            _interactor = new HeadRotatePlusInteractor();
            _robot = new Robot();
        }

        [Fact]
        public void NotExceedLimit()
        {
            HeadRotatePlusResponse response = null;

            response = _interactor.Handle(new HeadRotatePlusRequest{
                Head = _robot.Head
            });

            Assert.True(response.IsValid);
            Assert.Equal(45, _robot.Head.Rotate);

            response = _interactor.Handle(new HeadRotatePlusRequest{
                Head = _robot.Head
            });

            Assert.True(response.IsValid);
            Assert.Equal(90, _robot.Head.Rotate);

            response = _interactor.Handle(new HeadRotatePlusRequest{
                Head = _robot.Head
            });

            Assert.False(response.IsValid);
            Assert.Equal(90, _robot.Head.Rotate);
        }

        [Fact]
        public void NotRotateHeadIfDown()
        {
            _robot.Head.InclinationDown();

            var response = _interactor.Handle(new HeadRotatePlusRequest{
                Head = _robot.Head
            });

            Assert.False(response.IsValid);
            Assert.Equal(0, _robot.Head.Rotate);
        }
    }
}