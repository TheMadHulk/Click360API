using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Click360.API.Controllers
{
    /// <summary>
    /// Controller for log level endpoints
    /// </summary>
    public class LogLevelController : BaseAPIController
    {
        private static readonly ILogger Logger = Log.ForContext<LogLevelController>();

        /// <summary>
        /// Set the minimum Serilog logging level at runtime
        /// 1 = Debug
        /// 2 = Information
        /// 3 = Warning
        /// 4 = Error
        /// </summary>
        /// <param name="logEventLevel">Log event level (corresponds to Serilog.Events.LogEventLevel values)</param>
        /// <returns>200 status</returns>
        [HttpPost]
        [Route("SetSerilogLoggingLevel")]
        public ActionResult<string> SetSerilogLoggingLevel(int logEventLevel)
        {
            try
            {
                if (logEventLevel < 1 || logEventLevel > 4)
                {
                    return BadRequest();
                }

                SerilogLoggingLevelSwitch.SetLoggingLevel(logEventLevel);

                return Ok("Success!");
            }
            catch (Exception e)
            {
                Logger.Error(e, $"Failed to set logging level: {e.Message}");
                return HandleException(e, $"Failed to set logging level:{e.Message}");
            }
        }

        /// <summary>
        /// Get the minimum Serilog logging level at runtime
        /// 1 = Debug
        /// 2 = Information
        /// 3 = Warning
        /// 4 = Error
        /// </summary>
        /// <returns>LogEventLevel</returns>
        [HttpGet]
        [Route("GetSerilogLoggingLevel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<int> GetSerilogLoggingLevel()
        {
            try
            {
                return Ok((int)SerilogLoggingLevelSwitch.LevelSwitch.MinimumLevel);
            }
            catch (Exception e)
            {
                Logger.Error(e, $"Failed to get logging level: {e.Message}");
                return HandleException(e,  $"Failed to set logging level:{e.Message}");
            }
        }
    }
}
