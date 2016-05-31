using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace urbanair_v1.DAL
{
    public class SqlHelper
    {

        //增加删除修改数据
        // public static string str = WebConfigurationManager.ConnectionStrings["sqlConnectionString"].ToString();
        public static string str = "Server=tcp:d1v83zitrc.database.chinacloudapi.cn,1433;Database=uair;User ID=sqlAdmin@d1v83zitrc;Password=User@123;Trusted_Connection=False;Encrypt=True;";// Connection Timeout=30;";
        public static int ExecuteNonQuery(string sql, params SqlParameter[] p)
        {
            int i = 0;
            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                SqlCommand com = new SqlCommand(sql, con);
                com.CommandType = CommandType.Text;
                com.Parameters.AddRange(p);
                i = com.ExecuteNonQuery();
            }
            return i;
        }
        //查询表数据
        public static DataTable SqlDataTable(string sql, params SqlParameter[] p)
        {
            DataTable tab = new DataTable();
            using (SqlConnection con = new SqlConnection(str))
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.SelectCommand.CommandType = CommandType.Text;
                if (p != null)
                    da.SelectCommand.Parameters.AddRange(p);
                da.Fill(tab);

            }
            return tab;
        }
    }
}