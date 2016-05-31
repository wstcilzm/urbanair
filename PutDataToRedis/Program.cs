using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;
using Newtonsoft.Json;
using System.IO;
using System.Data.Spatial;
using System.Text.RegularExpressions;

namespace PutDataToRedis
{
    class Program
    {
        static void Main(string[] args)
        {
            //PutDistricts();
            //GetDistricts();
            //PutStations();
            //GetStations();
            //long s = PutCityAQICurrent();
            //AppendCityAQICurrent();
            //GetAQIByCityId();
            //PutDistrictAQICurrent();
            //AppendDistrictAQICurrent();
            //GetAQIByDistrictId();
            //PutStationAQICurrent();
            //AppendStationAQICurrent();
            GetAQIByStationId();
            //PustStationAQIByCityId();
            //GetStationsAQIByCityId();
            //PutAQIPredictionByCity();
            //GetAQIPredictionByCityId();
            //PutAQIPredictionByStationId();
            //GetAQIPredictionByStationId();
            //PutStationAQIPredictionByCity();
            GetStationAQIPredictionByCity();
            Console.Read();
        }


        async static void PutDistricts()
        {
            string[] files = Directory.GetFiles("GetDistrictById");
            List<HashEntry> hashEntries = new List<HashEntry>();
            foreach (string fileName in files)
            {
                FileInfo info = new FileInfo(fileName);
                string text = File.ReadAllText(fileName);
                hashEntries.Add(new HashEntry(info.Name.Split('.')[0] ,text));
            }

            Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect("weatherDataCache.redis.cache.chinacloudapi.cn,abortConnect=false,ssl=true,password=PosYydGTduPZM05qtrydmaWAh9THAD5CkEKGHxnYfWs=");
            });

            IDatabase cache = lazyConnection.Value.GetDatabase();

            if (cache.KeyExists("districts"))
            {
                cache.KeyDelete("districts");
            }

            //cache.HashSet("districts", hashEntries.ToArray());
            await cache.HashSetAsync("districts", hashEntries.ToArray());

        }

        static void PutProvinces()
        {
            string provinces = File.ReadAllText("AllProvinceList.json");
            Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect("weatherDataCache.redis.cache.chinacloudapi.cn,abortConnect=false,ssl=true,password=PosYydGTduPZM05qtrydmaWAh9THAD5CkEKGHxnYfWs=");
            });

            IDatabase cache = lazyConnection.Value.GetDatabase();


            List<Province> myProvinces = JsonConvert.DeserializeObject<List<Province>>(provinces);

            List<HashEntry> entiterf = new List<HashEntry>();


            foreach (var myProvince in myProvinces)
            {
                entiterf.Add(new HashEntry(myProvince.Id, JsonConvert.SerializeObject(myProvince)));
            }

            if (cache.KeyExists("provinces"))
            {
                cache.KeyDelete("provinces");
            }


            //RedisValue[] provinces = cache.HashValues("cities");

            //City city = JsonConvert.DeserializeObject<City>(cache.HashGet("cities", "244"));


            //provinces[0].ToString();
            //JsonConvert.SerializeObject(provinces);


            cache.HashSet("provinces", entiterf.ToArray());
        }

        static void GetDistricts()
        {
            Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect("weatherDataCache.redis.cache.chinacloudapi.cn,abortConnect=false,ssl=true,password=PosYydGTduPZM05qtrydmaWAh9THAD5CkEKGHxnYfWs=");
            });

            IDatabase cache = lazyConnection.Value.GetDatabase();

            Task<HashEntry[]> districts = cache.HashGetAllAsync("districts");
            while(!districts.IsCompleted)
            {
                System.Threading.Thread.Sleep(1000);
            }
            var hs = districts.Result;

            Console.Read();

        }

        async static void PutStations()
        {
            string[] files = Directory.GetFiles("GetStationById");
            List<HashEntry> hashEntries = new List<HashEntry>();
            foreach (string fileName in files)
            {
                FileInfo info = new FileInfo(fileName);
                string text = File.ReadAllText(fileName);
                hashEntries.Add(new HashEntry(info.Name.Split('.')[0], text));
            }

            Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect("weatherDataCache.redis.cache.chinacloudapi.cn,abortConnect=false,ssl=true,password=PosYydGTduPZM05qtrydmaWAh9THAD5CkEKGHxnYfWs=");
            });

            IDatabase cache = lazyConnection.Value.GetDatabase();

            if (cache.KeyExists("stations"))
            {
                cache.KeyDelete("stations");
            }

            //cache.HashSet("districts", hashEntries.ToArray());
            await cache.HashSetAsync("stations", hashEntries.ToArray());
        }

        static HashEntry[] GetStations()
        {
            Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect("weatherDataCache.redis.cache.chinacloudapi.cn,abortConnect=false,ssl=true,password=PosYydGTduPZM05qtrydmaWAh9THAD5CkEKGHxnYfWs=");
            });

            IDatabase cache = lazyConnection.Value.GetDatabase();

            Task<HashEntry[]> stations = cache.HashGetAllAsync("stations");
            return stations.Result;
        }

        static long PutCityAQICurrent()
        {
            string[] files = Directory.GetFiles("GetAQIByCityId");
            List<SortedSetEntry> sortEntries = new List<SortedSetEntry>();
            Dictionary<double, Dictionary<string, string>> PutCityAQICurrent = new Dictionary<double, Dictionary<string, string>>();
            foreach (string fileName in files)
            {
                FileInfo info = new FileInfo(fileName);
                string text = File.ReadAllText(fileName);
                var cityId = info.Name.Split('.')[0];
                var obj = JsonConvert.DeserializeObject<AQI>(text);
                string[] dateTime = obj.Time.Split('T');
                string[] date = dateTime[0].Split('-');
                string[] time = dateTime[1].Split(':');
                var sb = new StringBuilder();
                foreach(var str in date)
                {
                    sb.Append(str);
                }
                sb.Append(time[0]);
                double score = double.Parse(sb.ToString());

                if(PutCityAQICurrent.Keys.Contains(score))
                {
                    PutCityAQICurrent[score][cityId] = text;
                }
                else
                {
                    PutCityAQICurrent[score] = new Dictionary<string, string>();
                    PutCityAQICurrent[score][cityId] = text;
                }

                
            }

            Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect("weatherDataCache.redis.cache.chinacloudapi.cn,abortConnect=false,ssl=true,password=PosYydGTduPZM05qtrydmaWAh9THAD5CkEKGHxnYfWs=");
            });

            IDatabase cache = lazyConnection.Value.GetDatabase();

            if (cache.KeyExists("city:aqi.current"))
            {
                cache.KeyDelete("city:aqi.current");
            }

            foreach (var keyValue in PutCityAQICurrent)
            {
                sortEntries.Add(new SortedSetEntry(JsonConvert.SerializeObject(keyValue.Value), keyValue.Key));
                
            }

            Task<long> result = cache.SortedSetAddAsync("city:aqi.current", sortEntries.ToArray());
            return result.Result;

            //cache.HashSet("districts", hashEntries.ToArray());

        }

        static long PutDistrictAQICurrent()
        {
            string[] files = Directory.GetFiles("GetAQIByDistrictId");
            List<SortedSetEntry> sortEntries = new List<SortedSetEntry>();
            Dictionary<double, Dictionary<string, string>> PutDistrictAQICurrent = new Dictionary<double, Dictionary<string, string>>();
            foreach (string fileName in files)
            {
                FileInfo info = new FileInfo(fileName);
                string text = File.ReadAllText(fileName);
                var districtId = info.Name.Split('.')[0];
                var obj = JsonConvert.DeserializeObject<AQI>(text);
                string[] dateTime = obj.Time.Split('T');
                string[] date = dateTime[0].Split('-');
                string[] time = dateTime[1].Split(':');
                var sb = new StringBuilder();
                foreach (var str in date)
                {
                    sb.Append(str);
                }
                sb.Append(time[0]);
                double score = double.Parse(sb.ToString());

                if (PutDistrictAQICurrent.Keys.Contains(score))
                {
                    PutDistrictAQICurrent[score][districtId] = text;
                }
                else
                {
                    PutDistrictAQICurrent[score] = new Dictionary<string, string>();
                    PutDistrictAQICurrent[score][districtId] = text;
                }


            }

            Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect("weatherDataCache.redis.cache.chinacloudapi.cn,abortConnect=false,ssl=true,password=PosYydGTduPZM05qtrydmaWAh9THAD5CkEKGHxnYfWs=");
            });

            IDatabase cache = lazyConnection.Value.GetDatabase();

            if (cache.KeyExists("district:aqi.current"))
            {
                cache.KeyDelete("district:aqi.current");
            }

            foreach (var keyValue in PutDistrictAQICurrent)
            {
                sortEntries.Add(new SortedSetEntry(JsonConvert.SerializeObject(keyValue.Value), keyValue.Key));

            }

            Task<long> result = cache.SortedSetAddAsync("district:aqi.current", sortEntries.ToArray());
            return result.Result;
        }

        static long PutStationAQICurrent()
        {
            string[] files = Directory.GetFiles("GetAQIByStationId");
            List<SortedSetEntry> sortEntries = new List<SortedSetEntry>();
            Dictionary<double, Dictionary<string, string>> PutStationAQICurrent = new Dictionary<double, Dictionary<string, string>>();
            foreach (string fileName in files)
            {
                FileInfo info = new FileInfo(fileName);
                string text = File.ReadAllText(fileName);
                var stationId = info.Name.Split('.')[0];
                AQI obj= null;
                try {
                    obj = JsonConvert.DeserializeObject<AQI>(text);
                }
                catch(Exception ex)
                {

                }
                if(obj==null)
                {
                    continue;
                }
                string[] dateTime = obj.Time.Split('T');
                string[] date = dateTime[0].Split('-');
                string[] time = dateTime[1].Split(':');
                var sb = new StringBuilder();
                foreach (var str in date)
                {
                    sb.Append(str);
                }
                sb.Append(time[0]);
                double score = double.Parse(sb.ToString());

                if (PutStationAQICurrent.Keys.Contains(score))
                {
                    PutStationAQICurrent[score][stationId] = text;
                }
                else
                {
                    PutStationAQICurrent[score] = new Dictionary<string, string>();
                    PutStationAQICurrent[score][stationId] = text;
                }


            }

            Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect("weatherDataCache.redis.cache.chinacloudapi.cn,abortConnect=false,ssl=true,password=PosYydGTduPZM05qtrydmaWAh9THAD5CkEKGHxnYfWs=");
            });

            IDatabase cache = lazyConnection.Value.GetDatabase();

            if (cache.KeyExists("station:aqi.current"))
            {
                cache.KeyDelete("station:aqi.current");
            }

            foreach (var keyValue in PutStationAQICurrent)
            {
                sortEntries.Add(new SortedSetEntry(JsonConvert.SerializeObject(keyValue.Value), keyValue.Key));

            }

            Task<long> result = cache.SortedSetAddAsync("station:aqi.current", sortEntries.ToArray());
            return result.Result;
        }

        static long PustStationAQIByCityId()
        {
            string[] files = Directory.GetFiles("GetStationAQIByCity");
            List<SortedSetEntry> sortEntries = new List<SortedSetEntry>();
            Dictionary<double, Dictionary<string, string>> PutStationsAQICurrent = new Dictionary<double, Dictionary<string, string>>();
            foreach (string fileName in files)
            {
                FileInfo info = new FileInfo(fileName);
                string text = File.ReadAllText(fileName);
                var cityId = info.Name.Split('.')[0];
                //var obj = JsonConvert.DeserializeObject<AQI>(text);
                Regex regex = new Regex(@"\d{4}-\d{2}-\d{2}T\d{2}(?=:)");
                Match match = regex.Match(text);
                string matchValue = match.Value;
                if(matchValue==null || matchValue==string.Empty)
                {
                    continue;
                }
                string[] dateTime = matchValue.Split('T');
                string[] date = dateTime[0].Split('-');
                string[] time = dateTime[1].Split(':');
                var sb = new StringBuilder();
                foreach (var str in date)
                {
                    sb.Append(str);
                }
                sb.Append(time[0]);
                double score = double.Parse(sb.ToString());

                if (PutStationsAQICurrent.Keys.Contains(score))
                {
                    PutStationsAQICurrent[score][cityId] = text;
                }
                else
                {
                    PutStationsAQICurrent[score] = new Dictionary<string, string>();
                    PutStationsAQICurrent[score][cityId] = text;
                }


            }

            Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect("weatherDataCache.redis.cache.chinacloudapi.cn,abortConnect=false,ssl=true,password=PosYydGTduPZM05qtrydmaWAh9THAD5CkEKGHxnYfWs=");
            });

            IDatabase cache = lazyConnection.Value.GetDatabase();

            if (cache.KeyExists("city.station:aqi.current"))
            {
                cache.KeyDelete("city.station:aqi.current");
            }

            foreach (var keyValue in PutStationsAQICurrent)
            {
                sortEntries.Add(new SortedSetEntry(JsonConvert.SerializeObject(keyValue.Value), keyValue.Key));

            }

            Task<long> result = cache.SortedSetAddAsync("city.station:aqi.current", sortEntries.ToArray());
            return result.Result;
        }

        static long PutAQIPredictionByCity()
        {
            string[] files = Directory.GetFiles("GetAQIPredictionByCityId");
            List<SortedSetEntry> sortEntries = new List<SortedSetEntry>();
            Dictionary<double, Dictionary<string, string>> PutAQIPredictionByCity = new Dictionary<double, Dictionary<string, string>>();
            foreach (string fileName in files)
            {
                FileInfo info = new FileInfo(fileName);
                string text = File.ReadAllText(fileName);
                var cityId = info.Name.Split('.')[0];
                //var obj = JsonConvert.DeserializeObject<AQI>(text);
                Regex regex = new Regex(@"(?<=""PredictTime"":"").+?(?="",)");
                Match match = regex.Match(text);
                string matchValue = match.Value;
                if (matchValue == null || matchValue == string.Empty)
                {
                    continue;
                }
                string[] dateTime = matchValue.Split('T');
                string[] date = dateTime[0].Split('-');
                string[] time = dateTime[1].Split(':');
                var sb = new StringBuilder();
                foreach (var str in date)
                {
                    sb.Append(str);
                }
                sb.Append(time[0]);
                double score = double.Parse(sb.ToString());

                if (PutAQIPredictionByCity.Keys.Contains(score))
                {
                    PutAQIPredictionByCity[score][cityId] = text;
                }
                else
                {
                    PutAQIPredictionByCity[score] = new Dictionary<string, string>();
                    PutAQIPredictionByCity[score][cityId] = text;
                }


            }

            Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect("weatherDataCache.redis.cache.chinacloudapi.cn,abortConnect=false,ssl=true,password=PosYydGTduPZM05qtrydmaWAh9THAD5CkEKGHxnYfWs=");
            });

            IDatabase cache = lazyConnection.Value.GetDatabase();

            if (cache.KeyExists("city:aqi.prediction"))
            {
                cache.KeyDelete("city:aqi.prediction");
            }

            foreach (var keyValue in PutAQIPredictionByCity)
            {
                sortEntries.Add(new SortedSetEntry(JsonConvert.SerializeObject(keyValue.Value), keyValue.Key));

            }

            Task<long> result = cache.SortedSetAddAsync("city:aqi.prediction", sortEntries.ToArray());
            return result.Result;
        }

        static long PutAQIPredictionByStationId()
        {
            string[] files = Directory.GetFiles("GetAQIPredictionByStationId");
            List<SortedSetEntry> sortEntries = new List<SortedSetEntry>();
            Dictionary<double, Dictionary<string, string>> PutAQIPredictionByStation = new Dictionary<double, Dictionary<string, string>>();
            foreach (string fileName in files)
            {
                FileInfo info = new FileInfo(fileName);
                string text = File.ReadAllText(fileName);
                var stationId = info.Name.Split('.')[0];
                //var obj = JsonConvert.DeserializeObject<AQI>(text);
                Regex regex = new Regex(@"(?<=""PredictTime"":"").+?(?="",)");
                Match match = regex.Match(text);
                string matchValue = match.Value;
                if (matchValue == null || matchValue == string.Empty)
                {
                    continue;
                }
                string[] dateTime = matchValue.Split('T');
                string[] date = dateTime[0].Split('-');
                string[] time = dateTime[1].Split(':');
                var sb = new StringBuilder();
                foreach (var str in date)
                {
                    sb.Append(str);
                }
                sb.Append(time[0]);
                double score = double.Parse(sb.ToString());

                if (PutAQIPredictionByStation.Keys.Contains(score))
                {
                    PutAQIPredictionByStation[score][stationId] = text;
                }
                else
                {
                    PutAQIPredictionByStation[score] = new Dictionary<string, string>();
                    PutAQIPredictionByStation[score][stationId] = text;
                }


            }

            Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect("weatherDataCache.redis.cache.chinacloudapi.cn,abortConnect=false,ssl=true,password=PosYydGTduPZM05qtrydmaWAh9THAD5CkEKGHxnYfWs=");
            });

            IDatabase cache = lazyConnection.Value.GetDatabase();

            if (cache.KeyExists("station:aqi.prediction"))
            {
                cache.KeyDelete("station:aqi.prediction");
            }

            foreach (var keyValue in PutAQIPredictionByStation)
            {
                sortEntries.Add(new SortedSetEntry(JsonConvert.SerializeObject(keyValue.Value), keyValue.Key));

            }

            Task<long> result = cache.SortedSetAddAsync("station:aqi.prediction", sortEntries.ToArray());
            return result.Result;
        }

        static long PutStationAQIPredictionByCity()
        {
            string[] files = Directory.GetFiles("GetStationAQIPredictionByCity");
            List<SortedSetEntry> sortEntries = new List<SortedSetEntry>();
            Dictionary<double, Dictionary<string, string>> PutStationsAQIPrediction = new Dictionary<double, Dictionary<string, string>>();
            foreach (string fileName in files)
            {
                FileInfo info = new FileInfo(fileName);
                string text = File.ReadAllText(fileName);
                var cityId = info.Name.Split('.')[0];
                //var obj = JsonConvert.DeserializeObject<AQI>(text);
                Regex regex = new Regex(@"\d{4}-\d{2}-\d{2}T\d{2}(?=:)");
                Match match = regex.Match(text);
                string matchValue = match.Value;
                if (matchValue == null || matchValue == string.Empty)
                {
                    continue;
                }
                string[] dateTime = matchValue.Split('T');
                string[] date = dateTime[0].Split('-');
                string[] time = dateTime[1].Split(':');
                var sb = new StringBuilder();
                foreach (var str in date)
                {
                    sb.Append(str);
                }
                sb.Append(time[0]);
                double score = double.Parse(sb.ToString());

                if (PutStationsAQIPrediction.Keys.Contains(score))
                {
                    PutStationsAQIPrediction[score][cityId] = text;
                }
                else
                {
                    PutStationsAQIPrediction[score] = new Dictionary<string, string>();
                    PutStationsAQIPrediction[score][cityId] = text;
                }


            }

            Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect("weatherDataCache.redis.cache.chinacloudapi.cn,abortConnect=false,ssl=true,password=PosYydGTduPZM05qtrydmaWAh9THAD5CkEKGHxnYfWs=");
            });

            IDatabase cache = lazyConnection.Value.GetDatabase();

            if (cache.KeyExists("city.station:aqi.prediction"))
            {
                cache.KeyDelete("city.station:aqi.prediction");
            }

            foreach (var keyValue in PutStationsAQIPrediction)
            {
                sortEntries.Add(new SortedSetEntry(JsonConvert.SerializeObject(keyValue.Value), keyValue.Key));

            }

            Task<long> result = cache.SortedSetAddAsync("city.station:aqi.prediction", sortEntries.ToArray());
            return result.Result;
        }

        static long AppendCityAQICurrent()
        {
            string[] files = Directory.GetFiles("GetAQIByCityId");
            List<SortedSetEntry> sortEntries = new List<SortedSetEntry>();
            Dictionary<double, Dictionary<string, string>> PutCityAQICurrent = new Dictionary<double, Dictionary<string, string>>();
            foreach (string fileName in files)
            {
                FileInfo info = new FileInfo(fileName);
                string text = File.ReadAllText(fileName);
                var cityId = info.Name.Split('.')[0];
                var obj = JsonConvert.DeserializeObject<AQI>(text);
                string[] dateTime = obj.Time.Split('T');
                string[] date = dateTime[0].Split('-');
                string[] time = dateTime[1].Split(':');
                var sb = new StringBuilder();
                foreach (var str in date)
                {
                    sb.Append(str);
                }
                sb.Append(time[0]);
                double score = double.Parse(sb.ToString());

                if (PutCityAQICurrent.Keys.Contains(score))
                {
                    PutCityAQICurrent[score][cityId] = text;
                }
                else
                {
                    PutCityAQICurrent[score] = new Dictionary<string, string>();
                    PutCityAQICurrent[score][cityId] = text;
                }


            }

            Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect("weatherDataCache.redis.cache.chinacloudapi.cn,abortConnect=false,ssl=true,password=PosYydGTduPZM05qtrydmaWAh9THAD5CkEKGHxnYfWs=");
            });

            IDatabase cache = lazyConnection.Value.GetDatabase();

            //if (cache.KeyExists("city:aqi.current"))
            //{
            //    cache.KeyDelete("city:aqi.current");
            //}



            Task<SortedSetEntry[]> rel = cache.SortedSetRangeByRankWithScoresAsync("city:aqi.current", -48, -1, Order.Descending);
            var aqis = rel.Result;
            foreach (var aqi in aqis)
            {
                if(PutCityAQICurrent.Keys.Contains(aqi.Score))
                {
                    var origial = JsonConvert.DeserializeObject<Dictionary<string, string>>(aqi.Element);
                    foreach(var pair in origial)
                    {
                        if(!PutCityAQICurrent[aqi.Score].Keys.Contains(pair.Key))
                        {
                            PutCityAQICurrent[aqi.Score].Add(pair.Key, pair.Value);
                        }
                    }
                }
               
            }



            foreach (var keyValue in PutCityAQICurrent)
            {
                sortEntries.Add(new SortedSetEntry(JsonConvert.SerializeObject(keyValue.Value), keyValue.Key));

            }

            Task<long> result = cache.SortedSetAddAsync("city:aqi.current", sortEntries.ToArray());
            return result.Result;

        }

        static long AppendDistrictAQICurrent()
        {
            string[] files = Directory.GetFiles("GetAQIByDistrictId");
            List<SortedSetEntry> sortEntries = new List<SortedSetEntry>();
            Dictionary<double, Dictionary<string, string>> PutDisctrictAQICurrent = new Dictionary<double, Dictionary<string, string>>();
            foreach (string fileName in files)
            {
                FileInfo info = new FileInfo(fileName);
                string text = File.ReadAllText(fileName);
                var disctrictId = info.Name.Split('.')[0];
                var obj = JsonConvert.DeserializeObject<AQI>(text);
                string[] dateTime = obj.Time.Split('T');
                string[] date = dateTime[0].Split('-');
                string[] time = dateTime[1].Split(':');
                var sb = new StringBuilder();
                foreach (var str in date)
                {
                    sb.Append(str);
                }
                sb.Append(time[0]);
                double score = double.Parse(sb.ToString());

                if (PutDisctrictAQICurrent.Keys.Contains(score))
                {
                    PutDisctrictAQICurrent[score][disctrictId] = text;
                }
                else
                {
                    PutDisctrictAQICurrent[score] = new Dictionary<string, string>();
                    PutDisctrictAQICurrent[score][disctrictId] = text;
                }


            }

            Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect("weatherDataCache.redis.cache.chinacloudapi.cn,abortConnect=false,ssl=true,password=PosYydGTduPZM05qtrydmaWAh9THAD5CkEKGHxnYfWs=");
            });

            IDatabase cache = lazyConnection.Value.GetDatabase();

            Task<SortedSetEntry[]> rel = cache.SortedSetRangeByRankWithScoresAsync("district:aqi.current", -48, -1, Order.Descending);
            var aqis = rel.Result;
            foreach (var aqi in aqis)
            {
                if (PutDisctrictAQICurrent.Keys.Contains(aqi.Score))
                {
                    var origial = JsonConvert.DeserializeObject<Dictionary<string, string>>(aqi.Element);
                    foreach (var pair in origial)
                    {
                        if (!PutDisctrictAQICurrent[aqi.Score].Keys.Contains(pair.Key))
                        {
                            PutDisctrictAQICurrent[aqi.Score].Add(pair.Key, pair.Value);
                        }
                    }
                }

            }



            foreach (var keyValue in PutDisctrictAQICurrent)
            {
                sortEntries.Add(new SortedSetEntry(JsonConvert.SerializeObject(keyValue.Value), keyValue.Key));

            }

            Task<long> result = cache.SortedSetAddAsync("district:aqi.current", sortEntries.ToArray());
            return result.Result;
        }

        static long AppendStationAQICurrent()
        {
            string[] files = Directory.GetFiles("GetAQIByStationId");
            List<SortedSetEntry> sortEntries = new List<SortedSetEntry>();
            Dictionary<double, Dictionary<string, string>> PutStationAQICurrent = new Dictionary<double, Dictionary<string, string>>();
            foreach (string fileName in files)
            {
                FileInfo info = new FileInfo(fileName);
                string text = File.ReadAllText(fileName);
                var stationId = info.Name.Split('.')[0];
                AQI obj = null;
                try
                {
                    obj = JsonConvert.DeserializeObject<AQI>(text);
                }
                catch (Exception ex)
                {

                }
                if (obj == null)
                {
                    continue;
                }
                string[] dateTime = obj.Time.Split('T');
                string[] date = dateTime[0].Split('-');
                string[] time = dateTime[1].Split(':');
                var sb = new StringBuilder();
                foreach (var str in date)
                {
                    sb.Append(str);
                }
                sb.Append(time[0]);
                double score = double.Parse(sb.ToString());

                if (PutStationAQICurrent.Keys.Contains(score))
                {
                    PutStationAQICurrent[score][stationId] = text;
                }
                else
                {
                    PutStationAQICurrent[score] = new Dictionary<string, string>();
                    PutStationAQICurrent[score][stationId] = text;
                }
            }

            Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect("weatherDataCache.redis.cache.chinacloudapi.cn,abortConnect=false,ssl=true,password=PosYydGTduPZM05qtrydmaWAh9THAD5CkEKGHxnYfWs=");
            });

            IDatabase cache = lazyConnection.Value.GetDatabase();

            Task<SortedSetEntry[]> rel = cache.SortedSetRangeByRankWithScoresAsync("station:aqi.current", -48, -1, Order.Descending);
            var aqis = rel.Result;
            foreach (var aqi in aqis)
            {
                if (PutStationAQICurrent.Keys.Contains(aqi.Score))
                {
                    var origial = JsonConvert.DeserializeObject<Dictionary<string, string>>(aqi.Element);
                    foreach (var pair in origial)
                    {
                        if (!PutStationAQICurrent[aqi.Score].Keys.Contains(pair.Key))
                        {
                            PutStationAQICurrent[aqi.Score].Add(pair.Key, pair.Value);
                        }
                    }
                }

            }



            foreach (var keyValue in PutStationAQICurrent)
            {
                sortEntries.Add(new SortedSetEntry(JsonConvert.SerializeObject(keyValue.Value), keyValue.Key));

            }

            Task<long> result = cache.SortedSetAddAsync("station:aqi.current", sortEntries.ToArray());
            return result.Result;
        }

        static void GetAQIByCityId()
        {
            string key = SetRedisKey("city", "aqi", "current");
            string result = RetrieveDataByKeyAndRange(key, 0, 23, "001",false);
        }

        static void GetAQIByDistrictId()
        {
            string key = SetRedisKey("district", "aqi", "current");
            string result = RetrieveDataByKeyAndRange(key, 0, 23, "00101", false);
        }

        static void GetAQIByStationId()
        {
            string key = SetRedisKey("station", "aqi", "current");
            string result = RetrieveDataByKeyAndRange(key, 0, 23, "001001", true);
        }

        static void GetStationsAQIByCityId()
        {
            string key = SetRedisKey("city.station", "aqi", "current");
            string result = RetrieveDataByKeyAndRange(key, 0, 23, "001",false);
        }

        static void GetAQIPredictionByCityId()
        {
            string key = SetRedisKey("city", "aqi", "prediction");
            string result = RetrieveDataByKeyAndRange(key, 0, 23, "001",false);
        }

        static void GetAQIPredictionByStationId()
        {
            string key = SetRedisKey("station", "aqi", "prediction");
            string result = RetrieveDataByKeyAndRange(key, 0, 23, "001001", false);
        }

        static void GetStationAQIPredictionByCity()
        {
            string key = SetRedisKey("city.station", "aqi", "prediction");
            string result = RetrieveDataByKeyAndRange(key, 0, 23, "001", false);
        }

        /// <summary>
        /// build the redis key
        /// </summary>
        /// <param name="locationType">city or district or station</param>
        /// <param name="weatherType">aqi or airInfo</param>
        /// <param name="dataType">current or prediction</param>
        /// <returns>redis key</returns>
        static string SetRedisKey(string locationType, string weatherType, string dataType)
        {
            var sb = new StringBuilder();
            //sb.AppendFormat("{0}:{1}:{2}.{3}", locationType.Trim().ToLower(), locationId.Trim(), weatherType.Trim().ToLower(), dataType.Trim().ToLower());
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
        static string RetrieveDataByKeyAndRange(string key, int startIndex, int endIndex, string id,bool isHistory)
        {
            Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect("weatherDataCache.redis.cache.chinacloudapi.cn,abortConnect=false,ssl=true,password=PosYydGTduPZM05qtrydmaWAh9THAD5CkEKGHxnYfWs=");
            });

            IDatabase cache = lazyConnection.Value.GetDatabase();
            //if(startIndex==endIndex)
            //{
            //    int start = startIndex, end = endIndex;
            //    Dictionary<string, string> result;
            //    long length = cache.SortedSetLength(key);
            //    length = length > 3 ? 3 : length;
            //    //int length = 3;
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
            if(result.Trim(new char[] { '[',']'})==string.Empty)
            {
                return string.Empty;
            }
            return result;
            //}
            //return string.Empty;
        }
    }


    public class City
    {
        /// <summary>
        /// city id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// located province
        /// </summary>
        public string ProvinceId { get; set; }

        /// <summary>
        /// city chinese name
        /// </summary>
        public string ChineseName { get; set; }

        /// <summary>
        /// city english name
        /// </summary>
        public string EnglishName { get; set; }

        /// <summary>
        /// bottom latitude
        /// </summary>
        public double BottomLatitude { get; set; }

        /// <summary>
        /// up latitude
        /// </summary>
        public double UpLatitude { get; set; }

        /// <summary>
        /// left longitude
        /// </summary>
        public double LeftLongitude { get; set; }

        /// <summary>
        /// right longitude
        /// </summary>
        public double RightLongitude { get; set; }

        /// <summary>
        /// center latitude
        /// </summary>
        public double CenterLatitude { get; set; }

        /// <summary>
        /// center longitude
        /// </summary>
        public double CenterLongitude { get; set; }

        private DbGeography cityGeo;
        /// <summary>
        /// 
        /// </summary>
        public DbGeography CityGeo
        {
            get
            {
                var sb = new StringBuilder();
                sb.Append(@"POLYGON((");
                sb.Append(LeftLongitude + " " + UpLatitude + "," + RightLongitude + " " + UpLatitude + "," + RightLongitude + " " + BottomLatitude + "," + LeftLongitude + " " + BottomLatitude + "," + LeftLongitude + " " + UpLatitude);
                sb.Append(@"))");
                cityGeo = DbGeography.PolygonFromText(sb.ToString(), 4326);
                return cityGeo;
            }

            set
            {
                cityGeo = value;
            }
        }

        /// <summary>
        /// district id list
        /// </summary>
        public IEnumerable<string> DistrictIdList { get; set; }


    }

    public class Province
    {
        /// <summary>
        /// province id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// province chinese name
        /// </summary>
        public string ChineseName { get; set; }

        /// <summary>
        /// province english name
        /// </summary>
        public string EnglishName { get; set; }

        /// <summary>
        /// bottom latitude
        /// </summary>
        public double BottomLatitude { get; set; }

        /// <summary>
        /// up latitude
        /// </summary>
        public double UpLatitude { get; set; }

        /// <summary>
        /// left longitude
        /// </summary>
        public double LeftLongitude { get; set; }

        /// <summary>
        /// right longitude
        /// </summary>
        public double RightLongitude { get; set; }

        /// <summary>
        /// center latitude
        /// </summary>
        public double CenterLatitude { get; set; }

        /// <summary>
        /// center longitude
        /// </summary>
        public double CenterLongitude { get; set; }

        private DbGeography provinceGeo;
        /// <summary>
        /// Represents a geography shapes of province.
        /// </summary>
        public DbGeography ProvinceGeo {
            get
            {
                var sb = new StringBuilder();
                sb.Append(@"POLYGON((");
                sb.Append(LeftLongitude + " " + UpLatitude + "," + RightLongitude + " " + UpLatitude + "," + RightLongitude + " " + BottomLatitude + "," + LeftLongitude + " " + BottomLatitude + "," + LeftLongitude + " " + UpLatitude);
                sb.Append(@"))");
                provinceGeo = DbGeography.PolygonFromText(sb.ToString(), 4326);
                return provinceGeo;
            }

            set
            {
                provinceGeo = value;
            }
        }


        /// <summary>
        /// city id list
        /// </summary>
        public IEnumerable<string> CityIdList { get; set; }
    }

    public class AQI
    {
        public string Time { get; set; }
        /// <summary>
        /// PM2.5 index for air quality
        /// </summary>
        public int? PM25 { get; set; }

        /// <summary>
        /// PM10 index for air quality
        /// </summary>
        public int? PM10 { get; set; }

        /// <summary>
        /// NO2 index for air quality
        /// </summary>
        public int? NO2 { get; set; }

        /// <summary>
        /// CO index for air quality
        /// </summary>
        public int? CO { get; set; }

        /// <summary>
        /// O3 index for air quality
        /// </summary>
        public int? O3 { get; set; }

        /// <summary>
        /// SO2 index for air quality
        /// </summary>
        public int? SO2 { get; set; }
    }
}
