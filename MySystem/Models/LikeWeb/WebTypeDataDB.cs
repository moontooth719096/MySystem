using System;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;

namespace MySystem.Models
{
    public class WebTypeDataDB:DbContext
    {
        private string ConnetStr = "Data Source=WIN-2ECGC9BV1OA;Initial Catalog=MySystemManagement;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
        private string Message = "";

        //類別ID
        public string WebTypeID{get;set;}
        //類別英文名稱
        public string WebTypeENName{get;set;}
        //類別中文名稱
        public string WebTypeCNName { get; set; }


        public DataTable getWebType()
        {
            SqlConnection myConn = new SqlConnection(ConnetStr);
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM WebTypeData";
            SqlCommand cmd = new SqlCommand(sql, myConn);
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                Message = ex.ToString();
                return dt;
            }
            finally
            {
                cmd.Cancel();
                myConn.Close();
                myConn.Dispose();
            }

        }
    }
}