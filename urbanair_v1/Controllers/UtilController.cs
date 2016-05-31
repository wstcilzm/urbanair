using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace urbanair_v1.Controllers
{
    /// <summary>
    /// util controller
    /// </summary>
    [RoutePrefix("UrbanAir/Util")]
    public class UtilController : ApiController
    {
        /// <summary>
        /// get supported city id list by method name
        /// </summary>
        /// <param name="methodName">method name</param>
        /// <returns>supported city id list</returns>
        [Route("SupportedCityIds/{methodName}")]
        public string GetSupportedCityIdListByMethodName(string methodName)
        {
            return null;
        }
    }
}