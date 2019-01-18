using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VG.OrderProcessing.API.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        #region Common Methods

        /// <summary>
        /// Respond as success
        /// </summary>
        /// <returns></returns>
        protected IActionResult Success()
        {
            return new JsonResult(new { Success = true });
        }

        /// <summary>
        /// Respond with exception
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        protected IActionResult Fail(Exception ex)
        {
            return new JsonResult(new { error = ex });
        }

        /// <summary>
        /// Respond with success with data object
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        protected IActionResult Success(object data)
        {
            return new JsonResult(new { success = true, model = data });
        }

        /// <summary>
        /// Respond with fail with data object
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        protected IActionResult Fail(object data)
        {
            return new JsonResult(new { success = false, model = data });
        }

        #endregion
    }
}