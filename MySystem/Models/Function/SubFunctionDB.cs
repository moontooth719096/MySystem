using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MySystem.Models.Function
{
    public class SubFunctionDB
    {

        //連接字串
        private string ConnetStr = "Data Source=WIN-2ECGC9BV1OA;Initial Catalog=MySystemManagement;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
        
        #region 查詢子功能
        /// <summary>
        /// 查詢工具選單子功能
        /// </summary>
        /// <returns>回傳子功能選單內容</returns>
        public DataTable QuerySubFunctionData()
        {
            SqlConnection myConn = new SqlConnection(ConnetStr);
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM SubFunctionData";
            SqlCommand cmd = new SqlCommand(sql, myConn);
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch
            {
                throw;
            }
            finally
            {
                cmd.Cancel();
                myConn.Close();
                myConn.Dispose();
            }
        }
        #endregion

        #region 新增主功能
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
            string count;
            try
            {
                count = (Convert.ToInt32(getCount()) + 1).ToString();
            }
            catch
            {
                throw;
            }

            SqlConnection myConn = new SqlConnection(ConnetStr);
            //連接資料庫
            myConn.Open();
            //先查詢目前筆數
            string sql = @"INSERT INTO SubFunctionData
                           (MainFunctionID,MainFunctionName,MainFunctionType) 
                           VALUES(@SubFunctionID,@SubFunctionENName,@SubFunctionCNName,@SubFunctionURL,@SubFunctionType)";
            SqlCommand cmd = new SqlCommand(sql, myConn);


            try
            {
                //執行新增
                cmd.Parameters.AddWithValue("@SubFunctionID", count);
                cmd.Parameters.AddWithValue("@SubFunctionENName", SubFunctionENName);
                cmd.Parameters.AddWithValue("@SubFunctionCNName", SubFunctionCNName);
                cmd.Parameters.AddWithValue("@SubFunctionURL", SubFunctionURL);
                cmd.Parameters.AddWithValue("@SubFunctionType", SubFunctionType);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                cmd.Cancel();
                myConn.Close();
                myConn.Dispose();
            }
            return "新增資料成功!";
        }
        /// <summary>
        /// 取得資料庫目前筆數
        /// </summary>
        /// <returns></returns>
        private string getCount()
        {
            SqlConnection myConn = new SqlConnection(ConnetStr);
            myConn.Open();
            //先查詢目前筆數
            string sql = "SELECT COUNT(MainFunctID) FROM MainFunctionData";
            SqlCommand cmd = new SqlCommand(sql, myConn);
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt.Rows[0][0].ToString();
            }
            catch
            {
                throw;
            }
            finally
            {
                cmd.Cancel();
                myConn.Close();
                myConn.Dispose();
            }
        }
        #endregion
    }
}