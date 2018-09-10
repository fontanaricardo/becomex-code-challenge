using RoboCore.Models;
using Xunit;

namespace RoboCore.Unit.Models
{
    public class RobotShould
    {
        private readonly Robot _robot;

        public RobotShould()
        {
            _robot = new Robot();
        }

        [Fact]
        public void InRestStateByDefault()
        {
            Assert.Equal(0, _robot.Head.Rotate);
            Assert.Equal(InclinationState.InRest, _robot.Head.InclinationState);
            Assert.Equal(0, _robot.LeftArm.Wrist.Rotate);
            Assert.Equal(0, _robot.RightArm.Wrist.Rotate);
            Assert.Equal(ElbowState.InRest, _robot.LeftArm.Elbow.ElbowState);
            Assert.Equal(ElbowState.InRest, _robot.RightArm.Elbow.ElbowState);
        }
    }
}