using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace urbanair_v1.Util
{
    /// <summary>
    /// 
    /// </summary>
    public class VersionInvoker
    {
      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="className"></param>
        /// <param name="method"></param>
        /// <param name="version"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string Invoke(string className,string method,double version,object[] args)
        {
            string v = version.ToString("N1");
            string[] subV = v.Split('.');
            string newClassName = className + "_"+subV[0] + "_" + subV[1];
            Type t = Type.GetType(newClassName);
            var api=Activator.CreateInstance(t);
            try
            {
                var result = t.InvokeMember(method, BindingFlags.InvokeMethod, null, api, args);
                if(result==null)
                {
                    return string.Empty;
                }
                return result.ToString();
            }
            catch(Exception)
            {
                return string.Empty;
            }
        }

    }
}
