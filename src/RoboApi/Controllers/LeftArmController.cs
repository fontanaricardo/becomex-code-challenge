using Microsoft.AspNetCore.Mvc;
using RoboCore.Business;
using RoboCore.Business.ElbowBusiness;
using RoboCore.Business.WristBusiness;
using RoboCore.Models;

namespace RoboApi.Controllers
{
    /// <summary>
    /// Control de left arm of the robot.
    /// </summary>
    [Route("api/robot/[controller]")]
    public class LeftArmController : ArmController
    {
        /// <summary>
        /// Control de left arm of the robot.
        /// </summary>
        public LeftArmController(
            Robot robot, 
            IRequestHandler<ElbowContractRequest, ElbowContractResponse> elbowContract, 
            IRequestHandler<ElbowRelaxRequest, ElbowRelaxResponse> elbowRelax, 
            IRequestHandler<WristPlusRotateRequest, WristPlusRotateResponse> wristPlusRotate, 
            IRequestHandler<WristMinusRotateRequest, WristMinusRotateResponse> wristMinusRotate) : base(robot, elbowContract, elbowRelax, wristPlusRotate, wristMinusRotate)
        {
        }

        protected override Arm Arm => Robot.LeftArm;
    }
}