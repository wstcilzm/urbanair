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
    [RoutePrefix("UrbanAir/AQI/{version}")]
    public class AirInfoController : ApiController
    {
        /// <summary>
        /// get air quality index info by city id
        /// </summary>
        /// <param name="version">api version</param>
        /// <param name="cityId">city id</param>
        /// <returns>air quality index info</returns>
        [Route("AQIInfoByCity/{cityId}")]
       public string GetAQIByCityId(double version,string cityId)
        {
            return VersionInvoker.Invoke("APIController", "GetAQIByCityId", version, new object[] { cityId });
        }

        /// <summary>
        /// get air quality index info by district id
        /// </summary>
        /// <param name="version">api version</param>
        /// <param name="districtId">district id</param>
        /// <returns>air quality index info</returns>
        [Route("AQIInfoByDistrict/{districtId}")]
        public string GetAQIByDistrictId(double version,string districtId)
        {
            return VersionInvoker.Invoke("APIController", "GetAQIByDistrictId", version, new object[] { districtId });
        }

        /// <summary>
        /// get air quality index info by microsoft station id
        /// </summary>
        /// <param name="msStationId">microsoft station id</param>
        /// <returns>air quality index info</returns>
        [Route("AQIInfoByMSStation/{stationId}")]
        public string GetAQIByMicrosoftStationId(string msStationId)
        {
            return null;
        }

        /// <summary>
        /// get air quality index info by station id
        /// </summary>
        /// <param name="version">api version</param>
        /// <param name="stationId">station id</param>
        /// <returns>air quality index info</returns>
        [Route("AQIInfoByStation/{stationId}")]
        public string GetAQIByStationId(double version,string stationId)
        {
            return VersionInvoker.Invoke("APIController", "GetAQIByStationId", version, new object[] { stationId });
        }

        /// <summary>
        /// get air quality index  history 24 hour by location
        /// </summary>
        /// <param name="latitude">latitude</param>
        /// <param name="longitude">longitude</param>
        /// <returns>air quality index infos</returns>
        [Route("AQIHIS24HourByLocation/{latitude}/{longitude}")]
        public string GetAQIHistory24HourByLocation(double latitude,double longitude)
        {
            return null;
        }

        /// <summary>
        /// get air quality indedx history 24 hour by microsoft station id
        /// </summary>
        /// <param name="msStationId">microsoft station id</param>
        /// <returns>air quality index infos</returns>
        [Route("AQIHIS24HourByMSStation/{msStationId}")]
        public string GetAQIHistory24HourByMicrosoftStationId(string msStationId)
        {
            return null;
        }

        /// <summary>
        ///get air quality index history 24 hour by  station id 
        /// </summary>
        /// <param name="version">api version</param>
        /// <param name="stationId">station id</param>
        /// <returns>air quality index infos</returns>
        [Route("AQIHIS24HourByStation/{stationId}")]
        public string GetAQIHistory24HourByStationId(double version,string stationId)
        {
            return VersionInvoker.Invoke("APIController", "GetAQIHistory24HourByStationId", version, new object[] { stationId });
        }

        /// <summary>
        /// get air quality index history 24 hour by city id 
        /// </summary>
        /// <param name="version">api version</param>
        /// <param name="cityId">city id</param>
        /// <returns>air quality index infos</returns>
        [Route("AQIHIS24HourByCity/{cityId}")]
        public string GetAQIHistory24HourByCityId(double version,string cityId)
        {
            return VersionInvoker.Invoke("APIController", "GetAQIHistory24HourByCityId", version, new object[] { cityId });
        }

        /// <summary>
        /// get air quality index history 24 hour by district id 
        /// </summary>
        /// <param name="version">api version</param>
        /// <param name="districtId">district id</param>
        /// <returns>air quality index infos</returns>
        [Route("AQIHIS24HourByDistrict/{districtId}")]
        public string GetAQIHistory24HourByDistrictId(double version,string districtId)
        {
            return VersionInvoker.Invoke("APIController", "GetAQIHistory24HourByDistrictId", version, new object[] { districtId });
        }

        /// <summary>
        /// get air quality index history by station id
        /// </summary>
        /// <param name="msStationId">microsoft station id</param>
        /// <returns></returns>
        [Route("AQIHISByMSStation/{msStationId}")]
        public string GetAQIHistoryByMicrosoftStationId(string msStationId)
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
        public string GetAQIInferenceByCityIdAndDetailLevel(string cityId,int detailLevel)
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
        public string GetAQIInferenceByLocation(double latitude,double longitude)
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
        public string GetAQIInferenceByRectAndDetailLevel(double upLatitude,double bottomLatitude, double leftLongtitude,double rightLongtitude,double detailLevel)
        {
            return null;
        }

        /// <summary>
        /// get air info by city
        /// </summary>
        /// <param name="cityId">city id</param>
        /// <returns>air info</returns>
        [Route("AirInfoByCity/{cityId}")]
        public string GetAirInfoByCity(string cityId)
        {
            return null;
        }

        /// <summary>
        /// get air info by location
        /// </summary>
        /// <param name="latitude">latitude</param>
        /// <param name="longitude">longitude</param>
        /// <returns></returns>
        [Route("AirInfoByLocation/{latitude}/{longitude}")]
        public string GetAirInfoByLocation(double latitude,double longitude)
        {
            return null;
        }

        /// <summary>
        /// get air info by station id
        /// </summary>
        /// <param name="stationId">station id</param>
        /// <returns>air info</returns>
        [Route("AirInfoByMSStation/{stationId}")]
        public string GetAirInfoByMSStation(string stationId)
        {
            return null;
        }

        /// <summary>
        /// get station air quality index by city id
        /// </summary>
        /// <param name="version">api version</param>
        /// <param name="cityId">city id</param>
        /// <returns>station air quality index</returns>
        [Route("StationAQIByCity/{cityId}")]
        public string GetStationAQIByCity(double version,string cityId)
        {
            return VersionInvoker.Invoke("APIController", "GetStationAQIByCity", version, new object[] { cityId });
        }
    }
}