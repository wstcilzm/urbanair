using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using urbanair_v1.Models;
using urbanair_v1.Util;

namespace urbanair_v1.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("UrbanAir/Prediction/{version}")]
    public class PredictionController : ApiController
    {
        /// <summary>
        /// predict AQI by city id
        /// </summary>
        /// <param name="version">api version</param>
        /// <param name="cityId">city id</param>
        /// <returns>aqi predictions</returns>
        [Route("PredictionByCity/{cityId}")]
        public string GetAQIPredictionByCityId(double version,string cityId)
        {
            return VersionInvoker.Invoke("APIController", "GetAQIPredictionByCityId", version, new object[] { cityId });
        }

        /// <summary>
        /// predict AQI by location 
        /// </summary>
        /// <param name="latitude">latitude</param>
        /// <param name="longitude">longitude</param>
        /// <returns>aqi predictions</returns>
        [Route("PredictionByLocation/{latitude}/{longitude}")]
        public string GetAQIPredictionByLocation(double latitude,double longitude)
        {
            return null;
        }

        /// <summary>
        /// predict AQI by station id
        /// </summary>
        /// <param name="version">api version</param>
        /// <param name="stationId">station id</param>
        /// <returns>aqi predictions</returns>
        [Route("PredictionByStation/{stationId}")]
        public string GetAQIPredictionByStationId(double version,string stationId)
        {
            return VersionInvoker.Invoke("APIController", "GetAQIPredictionByStationId", version, new object[] { stationId });
        }

        /// <summary>
        /// predict AQI by district id
        /// </summary>
        /// <param name="version">api version</param>
        /// <param name="districtId">district id</param>
        /// <returns>aqi predictions</returns>
        [Route("PredictionByDistrict/{districtId}")]
        public string GetAQIPredictionByDistrictId(double version,string districtId)
        {
            return VersionInvoker.Invoke("APIController", "GetAQIPredictionByDistrictId", version, new object[] { districtId });
        }

        /// <summary>
        /// get tomorrow air quality index prediction by city id
        /// </summary>
        /// <param name="cityId">city id</param>
        /// <returns>air quality index</returns>
        [Route("TWAQIPredictionByCity/{cityId}")]
        public string GetTomorrowAQIPredictionByCityId(string cityId)
        {
            return null;
        }

        /// <summary>
        /// get station aqi prediction by city
        /// </summary>
        /// <param name="version">api version</param>
        /// <param name="cityId">city id</param>
        /// <returns>station air quality index prediction</returns>
        [Route("StationAQIPredictionByCity/{cityId}")]
        public string GetStationAQIPredictionByCity(double version,string cityId)
        {
            return VersionInvoker.Invoke("APIController", "GetStationAQIPredictionByCity", version, new object[] { cityId });
        }
    }
}