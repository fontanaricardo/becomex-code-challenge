using Microsoft.AspNetCore.Mvc;
using RoboCore.Business;
using RoboCore.Business.ElbowBusiness;
using RoboCore.Business.WristBusiness;
using RoboCore.Models;

namespace RoboApi.Controllers
{
    /// <summary>
    /// Control the right arm of the robot.
    /// </summary>
    [Route("api/robot/[controller]")]
    public class RightArmController : ArmController
    {
        /// <summary>
        /// Control the right arm of the robot.
        /// </summary>
        public RightArmController(
            Robot robot, 
            IRequestHandler<ElbowContractRequest, ElbowContractResponse> elbowContract, 
            IRequestHandler<ElbowRelaxRequest, ElbowRelaxResponse> elbowRelax, 
            IRequestHandler<WristPlusRotateRequest, WristPlusRotateResponse> wristPlusRotate, 
            IRequestHandler<WristMinusRotateRequest, WristMinusRotateResponse> wristMinusRotate) : base(robot, elbowContract, elbowRelax, wristPlusRotate, wristMinusRotate)
        {
        }

        protected override Arm Arm => Robot.RightArm;
    }
}