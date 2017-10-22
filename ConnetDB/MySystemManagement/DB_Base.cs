using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace ConnetDB.MySystemManagement
{
     
    public class DB_Base : DbContext
    {
      public StringBuilder  connString;
      public SqlConnection Conn = new SqlConnection("");
      public void GetconnString(string ConnetDBName)
      {
          connString = new StringBuilder();
          connString.Append(System.Web.Configuration.WebConfigurationManager.ConnectionStrings[ConnetDBName].ToString());
          SetConn(connString.ToString());
      }
      
      public void SetConn(string ConnetString)
      {
          Conn = new SqlConnection(ConnetString);
      }
      //查詢
      public DataTable QueryExcute(SqlConnection Conn, string SQLString)
      {
          using (SqlConnection myConn = Conn)
          {
              DataTable dt = new DataTable();
              string sql = SQLString;
              using (SqlCommand cmd = new SqlCommand(sql, myConn))
              {
                  try
                  {
                      SqlDataAdapter da = new SqlDataAdapter(cmd);
                      da.Fill(dt);
                      return dt;
                  }
                  catch(Exception ex)
                  {
                      throw ex;
                  }
              }
          }
      }
    }
}