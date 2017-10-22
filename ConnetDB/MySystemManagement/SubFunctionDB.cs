using ConnetDB.MySystemManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ConnetDB.MySystemManagement
{
    public class SubFunctionDB:DB_Base
    {
        public SubFunctionDB()
        {
           string DBName = "MySystemDB";
           GetconnString(DBName);
        }

        #region 查詢子功能
        /// <summary>
        /// 查詢工具選單子功能
        /// </summary>
        /// <returns>回傳子功能選單內容</returns>
        public DataTable QuerySubFunctionData()
        {
            string sql = "SELECT * FROM SubFunctionData";
            return QueryExcute(Conn, sql);
        }
        #endregion

        #region 新增子功能
        /// <summary>
        /// 新增子功能
        /// </summary>
        /// <param name="SubFunctionENName">子功能英文名稱</param>
        /// <param name="SubFunctionCNName">子功能中文名稱</param>
        /// <param name="SubFunctionURL">子功能連結地址</param>
        /// <param name="SubFunctionType">功能類別</param>
        /// <returns></returns>
        public string addSubFunction(string SubFunctionENName, string SubFunctionCNName, string SubFunctionURL,string SubFunctionType)
        {
            DataTable SubFunctionDT = QuerySubFunctionData();
            int count = 0;
            if (SubFunctionDT != null && SubFunctionDT.Rows.Count > 0)
                count = SubFunctionDT.Rows.Count;

            //先查詢目前筆數
            string sql = @"INSERT INTO SubFunctionData
                           (MainFunctionID,MainFunctionName,MainFunctionType) 
                VALUES(@SubFunctionID,@SubFunctionENName,@SubFunctionCNName,@SubFunctionURL,@SubFunctionType)";
            try
            {
                using (SqlConnection myConn = Conn)
                {
                    using (SqlCommand cmd = new SqlCommand(sql, myConn))
                    {
                        //執行新增
                        cmd.Parameters.AddWithValue("@SubFunctionID", count);
                        cmd.Parameters.AddWithValue("@SubFunctionENName", SubFunctionENName);
                        cmd.Parameters.AddWithValue("@SubFunctionCNName", SubFunctionCNName);
                        cmd.Parameters.AddWithValue("@SubFunctionURL", SubFunctionURL);
                        cmd.Parameters.AddWithValue("@SubFunctionType", SubFunctionType);
                        cmd.ExecuteNonQuery();
                        return "新增資料成功!";
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                Conn.Close();
            }
            
        }
        #endregion
    }
}