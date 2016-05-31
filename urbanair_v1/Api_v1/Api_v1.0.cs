using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using urbanair_v1.Controllers;
using urbanair_v1.DAL;
using urbanair_v1.Util;

/// <summary>
/// 
/// </summary>
public class APIController_1_0
{
    private IDBConnection conn;
    /// <summary>
    /// 
    /// </summary>
    public APIController_1_0()
    {
        conn = DBObjFactory.CreateDbConnection("redis");
        if(conn==null)
        {
            conn= DBObjFactory.CreateDbConnection("sql");
        }
    }

    #region GeoApis

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public string GetCityList()
    {
        try
        {
            var result = conn.RetrieveAllCities();
            if (result != string.Empty)
            {
                return result;
            }
            else
            {
                var newConn = DBObjFactory.CreateDbConnection("sql");
                return newConn.RetrieveAllCities();
            }
        }
        catch(Exception)
        {
            return null;
        }
       
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string GetCityById(string id)
    {
        try
        {
            var result = conn.RetrieveCityById(id);
            if (result != string.Empty)
            {
                return result;
            }
            else
            {
                var newConn= DBObjFactory.CreateDbConnection("sql");
                return newConn.RetrieveCityById(id);
            }
        }
        catch (Exception)
        {
            return null;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string GetDistrictById(string id)
    {
        try
        {
            var result = conn.RetrieveDistrictById(id);
            if (result != string.Empty)
            {
                return result;
            }
            else
            {
                var newConn = DBObjFactory.CreateDbConnection("sql");
                return newConn.RetrieveDistrictById(id);
            }
        }
        catch (Exception)
        {
            return null;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string GetProvinceById(string id)
    {
        try
        {
            var result = conn.RetrieveProvinceById(id);
            if (result != string.Empty)
            {
                return result;
            }
            else
            {
                var newConn = DBObjFactory.CreateDbConnection("sql");
                return newConn.RetrieveProvinceById(id);
            }
        }
        catch (Exception)
        {
            return null;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public string GetProvinceList()
    {
        try
        {
            var result = conn.RetrieveAllProvinces();
            if (result != string.Empty)
            {
                return result;
            }
            else
            {
                var newConn = DBObjFactory.CreateDbConnection("sql");
                return newConn.RetrieveAllProvinces();
            }
        }
        catch (Exception)
        {
            return null;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string GetStationById(string id)
    {
        try
        {
            var result = conn.RetrieveStationById(id);
            if (result != string.Empty)
            {
                return result;
            }
            else
            {
                var newConn = DBObjFactory.CreateDbConnection("sql");
                return newConn.RetrieveStationById(id);
            }
        }
        catch (Exception)
        {
            return null;
        }
    }

    #endregion

    #region current air info

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cityId"></param>
    /// <returns></returns>
    public string GetAQIByCityId(string cityId)
    {
        try
        {
            var result = conn.RetrieveAQIByCityId(cityId);
            if (result != string.Empty)
            {
                return result;
            }
            else
            {
                var newConn = DBObjFactory.CreateDbConnection("sql");
                return newConn.RetrieveAQIByCityId(cityId);
            }
        }
        catch (Exception)
        {
            return null;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="districtId"></param>
    /// <returns></returns>
    public string GetAQIByDistrictId(string districtId)
    {
        try
        {
            var result = conn.RetrieveAQIByDistrictId(districtId);
            if (result != string.Empty)
            {
                return result;
            }
            else
            {
                var newConn = DBObjFactory.CreateDbConnection("sql");
                return newConn.RetrieveAQIByDistrictId(districtId);
            }
        }
        catch (Exception)
        {
            return null;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="stationId"></param>
    /// <returns></returns>
    public string GetAQIByStationId(string stationId)
    {
        try
        {
            var result = conn.RetrieveAQIByStationId(stationId);
            if (result != string.Empty)
            {
                return result;
            }
            else
            {
                var newConn = DBObjFactory.CreateDbConnection("sql");
                return newConn.RetrieveAQIByStationId(stationId);
            }
        }
        catch (Exception)
        {
            return null;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cityId"></param>
    /// <returns></returns>
    public string GetStationAQIByCity(string cityId)
    {
        try
        {
            var result = conn.RetrieveStationAQIByCityId(cityId);
            if (result != string.Empty)
            {
                return result;
            }
            else
            {
                var newConn = DBObjFactory.CreateDbConnection("sql");
                return newConn.RetrieveStationAQIByCityId(cityId);
            }
        }
        catch (Exception)
        {
            return null;
        }
    }

    #endregion

    #region history air info

    /// <summary>
    /// 
    /// </summary>
    /// <param name="stationId"></param>
    /// <returns></returns>
    public string GetAQIHistory24HourByStationId(string stationId)
    {
        try
        {
            var result = conn.RetrieveAQIHistory24HourByStationId(stationId);
            if (result != string.Empty)
            {
                return result;
            }
            else
            {
                var newConn = DBObjFactory.CreateDbConnection("sql");
                return newConn.RetrieveAQIHistory24HourByStationId(stationId);
            }
        }
        catch (Exception)
        {
            return null;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cityId"></param>
    /// <returns></returns>
    public string GetAQIHistory24HourByCityId(string cityId)
    {
        try
        {
            var result = conn.RetrieveAQIHistory24HourByCityId(cityId);
            if (result != string.Empty)
            {
                return result;
            }
            else
            {
                var newConn = DBObjFactory.CreateDbConnection("sql");
                return newConn.RetrieveAQIHistory24HourByCityId(cityId);
            }
        }
        catch (Exception)
        {
            return null;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="districtId"></param>
    /// <returns></returns>
    public string GetAQIHistory24HourByDistrictId(string districtId)
    {
        try
        {
            var result = conn.RetrieveAQIHistory24HourByDistrictId(districtId);
            if (result != string.Empty)
            {
                return result;
            }
            else
            {
                var newConn = DBObjFactory.CreateDbConnection("sql");
                return newConn.RetrieveAQIHistory24HourByDistrictId(districtId);
            }
        }
        catch (Exception)
        {
            return null;
        }
    }
    #endregion

    #region prediction air info

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cityId"></param>
    /// <returns></returns>
    public string GetAQIPredictionByCityId(string cityId)
    {
        try
        {
            var result = conn.RetrieveAQIPredictionByCityId(cityId);
            if (result != string.Empty)
            {
                return result;
            }
            else
            {
                var newConn = DBObjFactory.CreateDbConnection("sql");
                return newConn.RetrieveAQIPredictionByCityId(cityId);
            }
        }
        catch (Exception)
        {
            return null;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="stationId"></param>
    /// <returns></returns>
    public string GetAQIPredictionByStationId(string stationId)
    {
        try
        {
            var result = conn.RetrieveAQIPredictionByStationId(stationId);
            if (result != string.Empty)
            {
                return result;
            }
            else
            {
                var newConn = DBObjFactory.CreateDbConnection("sql");
                return newConn.RetrieveAQIPredictionByStationId(stationId);
            }
        }
        catch (Exception)
        {
            return null;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="districtId"></param>
    /// <returns></returns>
    public string GetAQIPredictionByDistrictId(string districtId)
    {
        try
        {
            var result = conn.RetrieveAQIPredictionByDistrictId(districtId);
            if (result != string.Empty)
            {
                return result;
            }
            else
            {
                var newConn = DBObjFactory.CreateDbConnection("sql");
                return newConn.RetrieveAQIPredictionByDistrictId(districtId);
            }
        }
        catch (Exception)
        {
            return null;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cityId"></param>
    /// <returns></returns>
    public string GetStationAQIPredictionByCity(string cityId)
    {
        try
        {
            var result = conn.RetrieveStationAQIPredictionByCityId(cityId);
            if (result != string.Empty)
            {
                return result;
            }
            else
            {
                var newConn = DBObjFactory.CreateDbConnection("sql");
                return newConn.RetrieveStationAQIPredictionByCityId(cityId);
            }
        }
        catch (Exception)
        {
            return null;
        }
    }
    #endregion
}


