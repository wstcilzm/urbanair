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
    [RoutePrefix("UrbanAir/AQI")]
    public class AirInfoController : ApiController
    {
        /// <summary>
        /// get air quality index info by city id
        /// </summary>
        /// <param name="cityId">city id</param>
        /// <returns>air quality index info</returns>
        [Route("AQIInfoByCity/{cityId}")]
       public AQI GetAQIByCityId(string cityId)
        {
            return null;
        }

        /// <summary>
        /// get air quality index info by district id
        /// </summary>
        /// <param name="districtId">district id</param>
        /// <returns>air quality index info</returns>
        [Route("AQIInfoByDistrict/{districtId}")]
        public AQI GetAQIByDistrictId(string districtId)
        {
            return null;
        }

        /// <summary>
        /// get air quality index info by microsoft station id
        /// </summary>
        /// <param name="msStationId">microsoft station id</param>
        /// <returns>air quality index info</returns>
        [Route("AQIInfoByMSStation/{stationId}")]
        public AQI GetAQIByMicrosoftStationId(string msStationId)
        {
            return null;
        }

        /// <summary>
        /// get air quality index info by station id
        /// </summary>
        /// <param name="stationId">station id</param>
        /// <returns>air quality index info</returns>
        [Route("AQIInfoByStation/{stationId}")]
        public AQI GetAQIByStationId(string stationId)
        {
            return null;
        }

        /// <summary>
        /// get air quality index  history 24 hour by location
        /// </summary>
        /// <param name="latitude">latitude</param>
        /// <param name="longitude">longitude</param>
        /// <returns>air quality index infos</returns>
        [Route("AQIHIS24HourByLocation/{latitude}/{longitude}")]
        public IEnumerable<AQI> GetAQIHistory24HourByLocation(double latitude,double longitude)
        {
            return null;
        }

        /// <summary>
        /// get air quality indedx history 24 hour by microsoft station id
        /// </summary>
        /// <param name="msStationId">microsoft station id</param>
        /// <returns>air quality index infos</returns>
        [Route("AQIHIS24HourByMSStation/{msStationId}")]
        public IEnumerable<AQI> GetAQIHistory24HourByMicrosoftStationId(string msStationId)
        {
            return null;
        }

        /// <summary>
        ///get air quality index history 24 hour by microsoft station id 
        /// </summary>
        /// <param name="stationId">station id</param>
        /// <returns>air quality index infos</returns>
        [Route("AQIHIS24HourByStation/{stationId}")]
        public IEnumerable<AQI> GetAQIHistory24HourByStationId(string stationId)
        {
            return null;
        }

        /// <summary>
        /// get air quality index history by station id
        /// </summary>
        /// <param name="msStationId"></param>
        /// <returns></returns>
        [Route("AQIHISByMSStation")]
        public IEnumerable<AQI> GetAQIHistoryByMicrosoftStationId(string msStationId)
        {
            return null;
        }

        /// <summary>
        /// get region air quality index by city id and detail level
        /// </summary>
        /// <param name="cityId">city id</param>
        /// <param name="detailLevel">detail level</param>
        /// <returns>region air quality index</returns>
        [Route("RegionAQIByCityAndLevel/{cityId}/{detailLevel}")]
        public IEnumerable<RegionAQI> GetAQIInferenceByCityIdAndDetailLevel(string cityId,int detailLevel)
        {
            return null;
        }

        /// <summary>
        /// get region air quality index by location
        /// </summary>
        /// <param name="latitude">latitude</param>
        /// <param name="longitude">longitude</param>
        /// <returns>region air quality index</returns>
        [Route("RegionAQIByLocation/{latitude}/{longitude}")]
        public IEnumerable<RegionAQI> GetAQIInferenceByLocation(double latitude,double longitude)
        {
            return null;
        }

        /// <summary>
        ///  get region air quality index by location and level
        /// </summary>
        /// <param name="upLatitude">up Latitude</param>
        /// <param name="bottomLatitude">bottom latitude</param>
        /// <param name="leftLongtitude">left longtitude</param>
        /// <param name="rightLongtitude">right longtitude</param>
        /// <param name="detailLevel">detail level</param>
        /// <returns>region air quality index</returns>
        [Route("RegionAQIByLocationAndLevel/{upLatitude}/{bottomLatitude}/{leftLongtitude}/{rightLongtitude}/{detailLevel}")]
        public IEnumerable<RegionAQI> GetAQIInferenceByRectAndDetailLevel(double upLatitude,double bottomLatitude, double leftLongtitude,double rightLongtitude,double detailLevel)
        {
            return null;
        }
    }
}