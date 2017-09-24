using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MySystem.Models.Function
{
    public class MainFunctionDB
    {

        //連接字串
        private string ConnetStr = "Data Source=WIN-2ECGC9BV1OA;Initial Catalog=MySystemManagement;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
        
        #region 查詢主主功能
        /// <summary>
        /// 查詢工具選單主功能
        /// </summary>
        /// <returns>回傳主功能選單內容</returns>
        public DataTable QueryMainFunctionData()
        {
            SqlConnection myConn = new SqlConnection(ConnetStr);
            DataTable dt = new DataTable();
            string sql = @"SELECT * FROM MainFunctionData
                           Order By MainFunctionID";
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
        /// 新增我的最愛資料
        /// </summary>
        /// <param name="WebName">網頁名稱</param>
        /// <param name="WebType">網業類型</param>
        /// <param name="WebURL">網址</param>
        /// <returns></returns>
        public string addMainFunction(string MainFunctionName, string MainFunctionType)
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
            string sql = @"INSERT INTO MainFunctionData
                           (MainFunctionID,MainFunctionName,MainFunctionType) 
                           VALUES(@MainFunctionID,@MainFunctionName,@MainFunctionType)";
            SqlCommand cmd = new SqlCommand(sql, myConn);


            try
            {
                //執行新增
                cmd.Parameters.AddWithValue("@MainFunctionID", count);
                cmd.Parameters.AddWithValue("@MainFunctionName", MainFunctionName);
                cmd.Parameters.AddWithValue("@MainFunctionType", MainFunctionType);
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
            string sql = "Select COUNT(MainFunctionID) From MainFunctionData";
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