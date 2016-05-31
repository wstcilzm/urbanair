using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using urbanair_v1.DAL;

namespace urbanair_v1.Util
{
    /// <summary>
    /// 
    /// </summary>
    public class DBObjFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IDBConnection CreateDbConnection(string dbType)
        {
            if (dbType == "redis")
            {
                return new RedisCacheDAO();
            }
            else if(dbType=="sqlserver")
            {
                return new SqlDAO();
            }
            return null;
        }
    }
}
