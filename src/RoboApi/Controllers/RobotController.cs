using Microsoft.AspNetCore.Mvc;
using RoboCore.Models;

namespace RoboApi.Controllers
{
    /// <summary>
    /// Get information about robot state.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RobotController : ControllerBase
    {
        private readonly Robot _robot;

        /// <summary>
        /// Get information about robot state.
        /// </summary>
        public RobotController(Robot robot)
        {
            _robot = robot;
        }

        /// <summary>
        /// Get information about robot.
        /// </summary>
        /// <returns>The robot current states information.</returns>
        [ProducesResponseType(200)]
        [HttpGet]
        public ActionResult<Robot> Get()
        {
            return _robot;
        }
    }
}