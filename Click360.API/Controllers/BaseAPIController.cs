using System;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Click360.API.Controllers
{
    /// <summary>
    /// Base class for all API controllers
    /// </summary>
    [ApiController]
    [Route("API/[controller]")]
    public class BaseAPIController : ControllerBase
    {

        /// <summary>
        /// Generic method to handle exceptions for HttpResponseMessage.
        /// </summary>
        /// <param name="exp"></param>
        /// <param name="userErrorMessage">Safe error message to display to the user</param>
        /// <param name="httpStatus">error status to display to the user</param>
        /// <returns></returns>
        protected ActionResult HandleException(Exception exp, string userErrorMessage, HttpStatusCode httpStatus = HttpStatusCode.InternalServerError)
        {
#if DEBUG
            return StatusCode((int)httpStatus, $"{userErrorMessage}: {exp.Message}");
#else
            return StatusCode((int)httpStatus, userErrorMessage);
#endif
        }
    }
}
