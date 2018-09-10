using Microsoft.AspNetCore.Mvc;
using RoboCore.Business;
using RoboCore.Business.HeadBusiness;
using RoboCore.Models;

namespace RoboApi.Controllers
{
    /// <summary>
    /// Control's the robot head.
    /// </summary>
    [Route("api/robot/[controller]")]
    [ApiController]
    public class HeadController : ControllerBase
    {
        private readonly Robot _robot;

        private readonly IRequestHandler<HeadRotatePlusRequest, HeadRotatePlusResponse> _plusRotateInteractor;
        private readonly IRequestHandler<HeadRotateMinusRequest, HeadRotateMinusResponse> _minusRotateInteractor;
        private readonly IRequestHandler<HeadInclinationUpRequest, HeadInclinationUpResponse> _headInclinationUpInteractor;
        private readonly IRequestHandler<HeadInclinationDownRequest, HeadInclinationDownResponse> _headInclinationDownInteractor;

        /// <summary>
        /// Control's the robot head.
        /// </summary>
        public HeadController(
            Robot robot, 
            IRequestHandler<HeadRotateMinusRequest, HeadRotateMinusResponse> minusRotateInteractor, 
            IRequestHandler<HeadRotatePlusRequest, HeadRotatePlusResponse> plusRotateInteractor,
            IRequestHandler<HeadInclinationUpRequest, HeadInclinationUpResponse> headInclinationUpInteractor,
            IRequestHandler<HeadInclinationDownRequest, HeadInclinationDownResponse> headInclinationDownInteractor)
        {
            _robot = robot;
            _minusRotateInteractor = minusRotateInteractor;
            _plusRotateInteractor = plusRotateInteractor;
            _headInclinationUpInteractor = headInclinationUpInteractor;
            _headInclinationDownInteractor = headInclinationDownInteractor;
        }

        /// <summary>
        /// Tilts head up.
        /// </summary>
        /// <response code="204">No return content if success.</response>
        /// <response code="400">Return bad request if request is invalid.</response>
        [HttpPost]
        [Route(nameof(InclinationUp))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public ActionResult<Robot> InclinationUp()
        {
            var response = _headInclinationUpInteractor.Handle(new HeadInclinationUpRequest
            {
                Head = _robot.Head
            });

            return ThreatResponse(response);
        }

        /// <summary>
        /// Tilts head down.
        /// </summary>
        /// <response code="204">No return content if success.</response>
        /// <response code="400">Return bad request if request is invalid.</response>
        [HttpPost]
        [Route(nameof(InclinationDown))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public ActionResult<Robot> InclinationDown()
        {
            var response = _headInclinationDownInteractor.Handle(new HeadInclinationDownRequest
            {
                Head = _robot.Head
            });

            return ThreatResponse(response);
        }

        /// <summary>
        /// Increases the head rotation.
        /// </summary>
        /// <response code="204">No return content if success.</response>
        /// <response code="400">Return bad request if request is invalid.</response>
        [HttpPost]
        [Route(nameof(PlusRotate))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public ActionResult<Robot> PlusRotate()
        {
            var response = _plusRotateInteractor.Handle(new HeadRotatePlusRequest
            {
                Head = _robot.Head
            });

            return ThreatResponse(response);
        }

        /// <summary>
        /// Decreases the head rotation.
        /// </summary>
        /// <response code="204">No return content if success.</response>
        /// <response code="400">Return bad request if request is invalid.</response>
        [HttpPost]
        [Route(nameof(MinusRotate))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public ActionResult<Robot> MinusRotate()
        {
            var response = _minusRotateInteractor.Handle(new HeadRotateMinusRequest
            {
                Head = _robot.Head
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