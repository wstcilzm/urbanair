using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace urbanair_v1.DAL
{
    /// <summary>
    /// 
    /// </summary>
    public class SqlDAO:IDBConnection
    {
        /// <summary>
        /// 
        /// </summary>
        public string ConStr { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public void InitializeConnection()
        {
             
        }


     

        /// <summary>
        /// get all provinces
        /// </summary>
        /// <returns></returns>
        public string RetrieveAllProvinces()
        {
            throw new Exception("not implement");
        }

        /// <summary>
        /// get province by province id
        /// </summary>
        /// <param name="provinceId"></param>
        /// <returns></returns>
        public string RetrieveProvinceById(string provinceId)
        {
            throw new Exception("not implement");
        }

        /// <summary>
        /// get all cities 
        /// </summary>
        /// <returns></returns>
        public string RetrieveAllCities()
        {
            throw new Exception("not implement");
        }

        /// <summary>
        /// get city by city id
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        public string RetrieveCityById(string cityId)
        {
            throw new Exception("not implement");
        }

        /// <summary>
        /// get district by district id 
        /// </summary>
        /// <param name="districtId"></param>
        /// <returns></returns>
        public string RetrieveDistrictById(string districtId)
        {
            throw new Exception("not implement");
        }

        /// <summary>
        /// get station by station id 
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        public string RetrieveStationById(string stationId)
        {
            throw new Exception("not implement");
        }

        /// <summary>
        /// get AQI By city id
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        public string RetrieveAQIByCityId(string cityId)
        {
            throw new Exception("not implement");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="districtId"></param>
        /// <returns></returns>
        public string RetrieveAQIByDistrictId(string districtId)
        {
            throw new Exception("not implement");
        }

        /// <summary>
        /// get all stations aqi by city id
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        public string RetrieveStationAQIByCityId(string cityId)
        {
            throw new Exception("not implement");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        public string RetrieveAQIByStationId(string stationId)
        {
            throw new Exception("not implement");
        }

        /// <summary>
        /// retrieve history 24 hour aqi by station id
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        public string RetrieveAQIHistory24HourByStationId(string stationId)
        {
            throw new Exception("not implement");
        }

        /// <summary>
        /// retrieve history 24 hour aqi by city id
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        public string RetrieveAQIHistory24HourByCityId(string cityId)
        {
            throw new Exception("not implement");
        }

        /// <summary>
        /// retrieve history 24 hour aqi by district id
        /// </summary>
        /// <param name="districtId"></param>
        /// <returns></returns>
        public string RetrieveAQIHistory24HourByDistrictId(string districtId)
        {
            throw new Exception("not implement");
        }

        /// <summary>
        /// retrieve prediction 48 hours aqi by city
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        public string RetrieveAQIPredictionByCityId(string cityId)
        {
            throw new Exception("not implement");
        }

        /// <summary>
        /// retrieve prediction 48 hours aqi by district
        /// </summary>
        /// <param name="districtId"></param>
        /// <returns></returns>
        public string RetrieveAQIPredictionByDistrictId(string districtId)
        {
            throw new Exception("not implement");
        }

        /// <summary>
        /// retrieve prediction 48 hours aqi by station
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        public string RetrieveAQIPredictionByStationId(string stationId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select top(1) * from AQIPREDICTION where locationtype=@LocationType")
                .Append(" and locationcode=@LocationCode order by TimeWindow Desc");
            SqlParameter[] par =
            {
                new SqlParameter("@LocationType",3),
                new SqlParameter("@LocationCode",stationId)
            };
            DataTable dt = SqlHelper.SqlDataTable(sb.ToString(), par);
            string value = "";
            if(dt!=null&&dt.Rows.Count>0)
            {
                value = dt.Rows[0]["Detail"].ToString();
            }
            return value;
        }

        /// <summary>
        /// retrieve all stations prediction 48 hours aqi by city
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        public string RetrieveStationAQIPredictionByCityId(string cityId)
        {
            throw new Exception("not implement");
        }

        public void Release()
        {
            return;
        }
    }
}
