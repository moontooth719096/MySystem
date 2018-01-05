using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace ConnetDB.MySystemDB
{
    public class SubFunctionDB : DB_Base, IDB_Base
    {
        string TBName = "SubFunctionData";
        public SubFunctionDB()
        {
           string DBName = "MySystemDB";
           GetconnString(DBName);
        }

        /// <summary>
        /// 查詢Tabel SubFunctionData
        /// </summary>
        /// <param name="Parameter"></param>
        /// <returns></returns>
        public DataTable getData(SQLParameter Parameter = null)
        {
            string SqlString = combinationQuerySQLString(Parameter, TBName);
            return QueryExcute(Conn, SqlString.ToString());
        }

        #region 新增子功能
        /// <summary>
        /// 新增子功能
        /// </summary>
        /// <param name="SubFunctionENName">子功能英文名稱</param>
        /// <param name="SubFunctionCNName">子功能中文名稱</param>
        /// <param name="SubFunctionURL">子功能連結地址</param>
        /// <param name="SubFunctionType">功能類別</param>
        /// <returns></returns>
        public string addSubFunction(string SubFunctionENName, string SubFunctionCNName, string SubFunctionURL,int SubFunctionType)
        {
            string sql = @"INSERT INTO SubFunctionData
                           VALUES(@SubFunctionENName,@SubFunctionCNName,@SubFunctionURL,@MainFunctionType)";
            try
            {
                using (SqlConnection myConn = Conn)
                {
                    myConn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, myConn))
                    {
                        //執行新增
                        //cmd.Parameters.AddWithValue("@SubFunctionID", count);
                        cmd.Parameters.AddWithValue("@SubFunctionENName", SubFunctionENName);
                        cmd.Parameters.AddWithValue("@SubFunctionCNName", SubFunctionCNName);
                        cmd.Parameters.AddWithValue("@SubFunctionURL", SubFunctionURL);
                        cmd.Parameters.AddWithValue("@MainFunctionType", Convert.ToInt32(SubFunctionType));
                        cmd.ExecuteNonQuery();
                        return "新增資料成功!";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conn.Close();
            }
            
        }
        #endregion

        public string addData(SQLParameter Parameter)
        {
            throw new NotImplementedException();
        }

        public string editData(SQLParameter Parameter)
        {
            throw new NotImplementedException();
        }

        public string deleteDate(SQLParameter Parameter)
        {
            StringBuilder SQLString = new StringBuilder();
            SQLString.Append(@"Delete " + TBName + " Where 1=1");
            foreach (var pa in Parameter.WhereCondition)
            {
                SQLString.Append(string.Concat(" And " + pa.Key + " =" + pa.Value));
            }
            bool Result = ExcuteAction(Conn, SQLString.ToString());
            if (Result)
                return "刪除成功!";
            else
                return "刪除失敗!";
        }
    }
}