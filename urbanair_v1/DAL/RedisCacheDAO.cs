using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;
using urbanair_v1.Models;
using Newtonsoft.Json;

namespace urbanair_v1.DAL
{
    /// <summary>
    /// Redis Data access Object
    /// </summary>
    public class RedisCacheDAO:IDBConnection
    {
        /// <summary>
        /// redis connection string
        /// </summary>
        public string ConStr { get; set; }

        private IDatabase cache;

        /// <summary>
        /// endpoint server
        /// </summary>
        public string HostName { get; set; }

        private static Lazy<ConnectionMultiplexer> lazyConnection;

        //private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        //{
        //    return ConnectionMultiplexer.Connect(System.Configuration.ConfigurationManager.ConnectionStrings["redisConnection"].ConnectionString);
        //});

        /// <summary>
        /// Connection to the redis cache
        /// </summary>
        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }

        /// <summary>
        /// not for using
        /// </summary>
        public void InitializeConnection()
        {
            cache = Connection.GetDatabase();
        }

        

        /// <summary>
        /// 
        /// </summary>
        public RedisCacheDAO()
        {
            InitializeConnection();
        }

        static RedisCacheDAO()
        {
            lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect(System.Configuration.ConfigurationManager.AppSettings["redisConnection"]);
            });
        }



        /// <summary>
        /// get all provinces
        /// </summary>
        /// <returns></returns>
        public string RetrieveAllProvinces()
        {
            Task<RedisValue[]> provinces =cache.HashValuesAsync("provinces");
            return JsonConvert.SerializeObject(provinces.Result);
        }

        /// <summary>
        /// get province by province id
        /// </summary>
        /// <param name="provinceId"></param>
        /// <returns></returns>
        public string RetrieveProvinceById(string provinceId)
        {
            Task<RedisValue> province= cache.HashGetAsync("provinces", provinceId);
            return province.Result;
        }

        /// <summary>
        /// get all cities 
        /// </summary>
        /// <returns></returns>
        public string RetrieveAllCities()
        {
            Task<RedisValue[]> cities = cache.HashValuesAsync("cities");
            return JsonConvert.SerializeObject(cities.Result);
        }

        /// <summary>
        /// get city by city id
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        public string RetrieveCityById(string cityId)
        {
            Task<RedisValue> city= cache.HashGetAsync("cities", cityId);
            return city.Result;
        }

        /// <summary>
        /// get district by district id 
        /// </summary>
        /// <param name="districtId"></param>
        /// <returns></returns>
        public string RetrieveDistrictById(string districtId)
        {
            Task<RedisValue> district= cache.HashGetAsync("districts", districtId);
            return district.Result;
        }

        /// <summary>
        /// get station by station id 
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        public string RetrieveStationById(string stationId)
        {
            Task<RedisValue> station = cache.HashGetAsync("stations", stationId);
            return station.Result;
            //return cache.HashGet("stations", stationId);
        }

        /// <summary>
        /// get AQI By city id
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        public string RetrieveAQIByCityId(string cityId)
        {
            string key = SetRedisKey("city", "aqi", "current");
            return RetrieveDataByKeyAndRange(key, 0, 23, cityId,false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="districtId"></param>
        /// <returns></returns>
        public string RetrieveAQIByDistrictId(string districtId)
        {
            string key = SetRedisKey("district","aqi", "current");
            return RetrieveDataByKeyAndRange(key, 0, 23, districtId,false);
        }

        /// <summary>
        /// get all stations aqi by city id
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        public string RetrieveStationAQIByCityId(string cityId)
        {
            string key = "city.station:aqi.current";
            return RetrieveDataByKeyAndRange(key, 0, 23, cityId,false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        public string RetrieveAQIByStationId(string stationId)
        {
            string key = SetRedisKey("station", "aqi", "current");
            return RetrieveDataByKeyAndRange(key, 0, 23, stationId,false);
        }

        /// <summary>
        /// retrieve history 24 hour aqi by station id
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        public string RetrieveAQIHistory24HourByStationId(string stationId)
        {
            string key = SetRedisKey("station", "aqi", "current");
            return RetrieveDataByKeyAndRange(key, 0, 23, stationId,true);
        }

        /// <summary>
        /// retrieve history 24 hour aqi by city id
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        public string RetrieveAQIHistory24HourByCityId(string cityId)
        {
            string key = SetRedisKey("city",  "aqi", "current");
            return RetrieveDataByKeyAndRange(key, 0, 23, cityId,true);
        }

        /// <summary>
        /// retrieve history 24 hour aqi by district id
        /// </summary>
        /// <param name="districtId"></param>
        /// <returns></returns>
        public string RetrieveAQIHistory24HourByDistrictId(string districtId)
        {
            string key = SetRedisKey("district",  "aqi", "current");
            return RetrieveDataByKeyAndRange(key, 0, 23, districtId,true);
        }

        /// <summary>
        /// retrieve prediction 48 hours aqi by city
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        public string RetrieveAQIPredictionByCityId(string cityId)
        {
            string key = SetRedisKey("city",  "aqi", "prediction");
            return RetrieveDataByKeyAndRange(key, 0, 23, cityId,false);
        }

        /// <summary>
        /// retrieve prediction 48 hours aqi by district
        /// </summary>
        /// <param name="districtId"></param>
        /// <returns></returns>
        public string RetrieveAQIPredictionByDistrictId(string districtId)
        {
            string key = SetRedisKey("district", "aqi", "prediction");
            return RetrieveDataByKeyAndRange(key, 0, 23, districtId,false);
        }

        /// <summary>
        /// retrieve prediction 48 hours aqi by station
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        public string RetrieveAQIPredictionByStationId(string stationId)
        {
            string key = SetRedisKey("station", "aqi", "prediction");
            return RetrieveDataByKeyAndRange(key, 0, 23, stationId,false);
        }

        /// <summary>
        /// retrieve all stations prediction 48 hours aqi by city
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        public string RetrieveStationAQIPredictionByCityId(string cityId)
        {
            string key = "city.station:aqi.prediction";
            return RetrieveDataByKeyAndRange(key, 0, 23, cityId,false);
        }

        /// <summary>
        /// build the redis key
        /// </summary>
        /// <param name="locationType">city or district or station</param>
        /// <param name="weatherType">aqi or airInfo</param>
        /// <param name="dataType">current or prediction</param>
        /// <returns>redis key</returns>
        private string SetRedisKey(string locationType, string weatherType,string dataType)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("{0}:{1}.{2}", locationType.Trim().ToLower(), weatherType.Trim().ToLower(), dataType.Trim().ToLower());
            return sb.ToString();
        }


        /// <summary>
        /// retrieve aqi current or history
        /// </summary>
        /// <param name="key">redis key</param>
        /// <param name="startIndex">sortedset start index</param>
        /// <param name="endIndex">sortedset end index</param>
        /// <param name="id">city id or district id or station id</param>
        /// <returns></returns>
        private string RetrieveDataByKeyAndRange(string key,int startIndex,int endIndex,string id, bool isHistory)
        {
            //Task<RedisValue[]> rel= cache.SortedSetRangeByRankAsync(key, startIndex, endIndex, Order.Descending);
            //var aqis = rel.Result;
            //if (aqis.Length ==1)
            //{
            //    var AQI = JsonConvert.DeserializeObject<Dictionary<string, string>>(aqis[0])[id];
            //    return AQI;
            //}
            //else if (aqis.Length > 1)
            //{
            //    var sb = new StringBuilder();
            //    sb.Append("[");
            //    foreach (var aqi in aqis)
            //    {
            //        var AQI = JsonConvert.DeserializeObject<Dictionary<string, string>>(aqi)[id];
            //        sb.AppendFormat("{0},", aqi);
            //    }
            //    string result = sb.ToString();
            //    return result.TrimEnd(new char[] { ',' }) + "]";
            //}
            //return string.Empty;
            //if (startIndex == endIndex)
            //{
            //    int start = startIndex, end = endIndex;
            //    Dictionary<string, string> result;
            //    //long length = cache.SortedSetLength(key);
            //    int length = 3;
            //    do
            //    {
            //        length--;
            //        Task<RedisValue[]> rel = cache.SortedSetRangeByRankAsync(key, start--, end--, Order.Ascending);
            //        var aqis = rel.Result;
            //        result = JsonConvert.DeserializeObject<Dictionary<string, string>>(aqis[0]);
            //    } while (!result.ContainsKey(id) && length > 0);
            //    if (result.ContainsKey(id))
            //    {
            //        return result[id];
            //    }
            //}
            //else
            //{
            //    Task<RedisValue[]> rel = cache.SortedSetRangeByRankAsync(key, startIndex, endIndex, Order.Ascending );
            //    var aqis = rel.Result;
            //    var sb = new StringBuilder();
            //    sb.Append("[");
            //    foreach (var aqi in aqis)
            //    {
            //        var cityAQI = JsonConvert.DeserializeObject<Dictionary<string, string>>(aqi);
            //        if (cityAQI.Keys.Contains(id))
            //        {
            //            sb.AppendFormat("{0},", cityAQI[id]);
            //        }
            //    }
            //    string result = sb.ToString();
            //    return result.TrimEnd(new char[] { ',' }) + "]";
            //}
            //return string.Empty;
            Task<RedisValue[]> rel = cache.SortedSetRangeByRankAsync(key, startIndex, endIndex, Order.Descending);
            var aqis = rel.Result;
            var sb = new StringBuilder();
            sb.Append("[");
            foreach (var aqi in aqis)
            {
                var data = JsonConvert.DeserializeObject<Dictionary<string, string>>(aqi);
                if (data.Keys.Contains(id))
                {
                    if (!isHistory)
                    {
                        return data[id];
                    }
                    sb.AppendFormat("{0},", data[id]);
                }
            }
            string result = sb.ToString();
            result = result.TrimEnd(new char[] { ',' }) + "]";
            if (result.Trim(new char[] { '[', ']' }) == string.Empty)
            {
                return string.Empty;
            }
            return result;
        }

        public void Release()
        {
            return;
        }
    }
}
