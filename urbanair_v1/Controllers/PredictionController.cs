using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using urbanair_v1.Models;

namespace urbanair_v1.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("Prediction")]
    public class PredictionController : ApiController
    {
        /// <summary>
        /// predict AQI by city id
        /// </summary>
        /// <param name="cityId">city id</param>
        /// <returns>aqi predictions</returns>
        [Route("PredictionByCity/{cityId}")]
        public IEnumerable<AQIPrediction> GetAQIPredictionByCityId(string cityId)
        {
            return null;
        }

        public 
    }
}