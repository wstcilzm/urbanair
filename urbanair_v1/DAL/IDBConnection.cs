using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace urbanair_v1.DAL
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDBConnection
    {
        /// <summary>
        /// connection string to database
        /// </summary>
        string ConStr { get; set; }


        /// <summary>
        /// initailize database connection
        /// </summary>
        void InitializeConnection();

        /// <summary>
        /// retrieve all provinces from database
        /// </summary>
        string RetrieveAllProvinces();

        /// <summary>
        /// retrieve province from database
        /// </summary>
        string RetrieveProvinceById(string provinceId);

        /// <summary>
        ///retrieve all cities from database 
        /// </summary>
        string RetrieveAllCities();

        /// <summary>
        /// retrieve city from database
        /// </summary>
        string RetrieveCityById(string cityId);

        /// <summary>
        ///retrieve district from database by district id
        /// </summary>
        /// <param name="districtId"></param>
        /// <returns></returns>
        string RetrieveDistrictById(string districtId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        string RetrieveStationById(string stationId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        string RetrieveAQIByCityId(string cityId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="districtId"></param>
        /// <returns></returns>
        string RetrieveAQIByDistrictId(string districtId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        string RetrieveStationAQIByCityId(string cityId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        string RetrieveAQIByStationId(string stationId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        string RetrieveAQIHistory24HourByStationId(string stationId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        string RetrieveAQIHistory24HourByCityId(string cityId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="districtId"></param>
        /// <returns></returns>
        string RetrieveAQIHistory24HourByDistrictId(string districtId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        string RetrieveAQIPredictionByCityId(string cityId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="districtId"></param>
        /// <returns></returns>
        string RetrieveAQIPredictionByDistrictId(string districtId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        string RetrieveAQIPredictionByStationId(string stationId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        string RetrieveStationAQIPredictionByCityId(string cityId);

        /// <summary>
        /// release database connection 
        /// </summary>
        void Release();
    }
}
