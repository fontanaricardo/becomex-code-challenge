using Microsoft.AspNetCore.Mvc;
using RoboCore.Business;
using RoboCore.Business.ElbowBusiness;
using RoboCore.Business.WristBusiness;
using RoboCore.Models;

namespace RoboApi.Controllers
{
    public abstract class ArmController : ControllerBase
    {
        private readonly IRequestHandler<ElbowContractRequest, ElbowContractResponse> _elbowContract;
        private readonly IRequestHandler<ElbowRelaxRequest, ElbowRelaxResponse> _elbowRelax;
        private readonly IRequestHandler<WristPlusRotateRequest, WristPlusRotateResponse> _wristPlusRotate;
        private readonly IRequestHandler<WristMinusRotateRequest, WristMinusRotateResponse> _wristMinusRotate;

        protected readonly Robot Robot;
        protected abstract Arm Arm { get; }

        public ArmController(
            Robot robot,
            IRequestHandler<ElbowContractRequest, ElbowContractResponse> elbowContract,
            IRequestHandler<ElbowRelaxRequest, ElbowRelaxResponse> elbowRelax,
            IRequestHandler<WristPlusRotateRequest, WristPlusRotateResponse> wristPlusRotate,
            IRequestHandler<WristMinusRotateRequest, WristMinusRotateResponse> wristMinusRotate)
        {
            Robot = robot;
            _elbowContract = elbowContract;
            _elbowRelax = elbowRelax;
            _wristPlusRotate = wristPlusRotate;
            _wristMinusRotate = wristMinusRotate;
        }

        /// <summary>
        /// Contract the Elbow.
        /// </summary>
        /// <response code="204">No return content if success.</response>
        /// <response code="400">Return bad request if request is invalid.</response>
        [HttpPost]
        [Route("ElbowContract")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public ActionResult ElbowContract()
        {
            var response = _elbowContract.Handle(new ElbowContractRequest
            {
                Arm = Arm
            });

            return ThreatResponse(response);
        }

        /// <summary>
        /// Relax the Elbow.
        /// </summary>
        /// <response code="204">No return content if success.</response>
        /// <response code="400">Return bad request if request is invalid.</response>
        [HttpPost]
        [Route("ElbowRelax")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public ActionResult ElbowRelax()
        {
            var response = _elbowRelax.Handle(new ElbowRelaxRequest
            {
                Arm = Arm
            });

            return ThreatResponse(response);
        }

        /// <summary>
        /// Increase the rotate of the wrist.
        /// </summary>
        /// <response code="204">No return content if success.</response>
        /// <response code="400">Return bad request if request is invalid.</response>
        [HttpPost]
        [Route("WristPlusRotate")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public ActionResult WristPlusRotate()
        {
            var response = _wristPlusRotate.Handle(new WristPlusRotateRequest
            {
                Arm = Arm
            });

            return ThreatResponse(response);
        }

        /// <summary>
        /// Decrease the rotate of the wrist.
        /// </summary>
        /// <response code="204">No return content if success.</response>
        /// <response code="400">Return bad request if request is invalid.</response>
        [HttpPost]
        [Route("WristMinusRotate")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public ActionResult WristMinusRotate()
        {
            var response = _wristMinusRotate.Handle(new WristMinusRotateRequest
            {
                Arm = Arm
            });

            return ThreatResponse(response);
        }

        private ActionResult ThreatResponse(BaseResponse response)
        {
            if (!response.IsValid)
            {
                return BadRequest(response.Errors);
            }

            return NoContent();
        }
    }
}