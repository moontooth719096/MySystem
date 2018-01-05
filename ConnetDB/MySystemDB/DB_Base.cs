using System;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Text;

namespace ConnetDB.MySystemDB
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

      /// <summary>
      /// 組合 Query SQLSteing
      /// </summary>
      /// <param name="Parameter"></param>
      /// <returns></returns>
      protected string combinationQuerySQLString(SQLParameter Parameter,string TBName)
      {
          StringBuilder SqlString = new StringBuilder();
          if (Parameter != null)
          {
              SqlString.Append("Select");
              if (Parameter.SelectField != null)
                  SqlString.Append(Parameter.SelectField);
              else
                  SqlString.Append("*");
              SqlString.Append(string.Concat(" From " + TBName + " "));
              if (Parameter.WhereCondition != null && Parameter.WhereCondition.Count > 0)
              {
                  SqlString.Append("Where ");
                  SqlString.Append(Parameter.WhereCondition);
              }
              if (Parameter.OrderByValue != null)
                  SqlString.Append(string.Concat("Order By " + Parameter.OrderByValue));
          }
          else
              SqlString.Append(string.Concat("Select * From " + TBName));
          return SqlString.ToString();
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
                      DataRow dr = dt.NewRow();
                      dt.Columns.Add("Code");
                      dt.Columns.Add("msg");
                      dr["Code"] = "-99";
                      dr["msg"] = ex.Message;
                      dt.Rows.Add(dr);
                      return dt;
                  }
              }
          }
      }

      protected bool ExcuteAction(SqlConnection Conn, string SQLString,SQLParameter Parameter =null)
      {
          using (SqlConnection myConn = Conn)
          {
              myConn.Open();
              SqlTransaction tran = myConn.BeginTransaction();    
              try
              {
                  int result = 0;
                using (SqlCommand cmd = new SqlCommand(SQLString, myConn, tran))
                {
                    if (Parameter !=null && Parameter.SetActionValue.Count > 0)
                    {
                        foreach (var pa in Parameter.SetActionValue)
                        {
                            cmd.Parameters.AddWithValue(pa.Key, pa.Value);
                        }
                    }
                    result = cmd.ExecuteNonQuery();
                }
                tran.Commit();//無錯誤 commit 
                if (result > 0)
                    return true;
                else
                    return false;
              }
              catch (Exception ex)
              {
                  tran.Rollback();//錯誤 rollback
                  return false;
              }
              finally
              {
                  Conn.Close();
              }
          }
      }
    }
}