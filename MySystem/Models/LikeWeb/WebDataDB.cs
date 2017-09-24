using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;

namespace MySystem.Models.LikeWeb
{
    public class WebDataDB : DbContext
        
    {
        //連接字串
        private string ConnetStr = "Data Source=WIN-2ECGC9BV1OA;Initial Catalog=MySystemManagement;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";

        #region 欄位
        public string WebID { get; set; }
        public string WebName { get; set; }
        public string WebType { get; set; }
        public string WebURL { get; set; }
        #endregion

        #region 取得我的最愛網頁資料
        /// <summary>
        /// //取得我的最愛網頁資料
        /// </summary>
        /// <returns>回傳查出的資料</returns>
        public DataTable getWebdata()
        {
            SqlConnection myConn = new SqlConnection(ConnetStr);
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM WebData";
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

        #region 新增我的最愛網頁
        /// <summary>
        /// 新增我的最愛資料
        /// </summary>
        /// <param name="WebName">網頁名稱</param>
        /// <param name="WebType">網業類型</param>
        /// <param name="WebURL">網址</param>
        /// <returns></returns>
        public string addWebdata(string WebName, string WebType, string WebURL)
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
            string sql = @"INSERT INTO WebData
                           (WebID,WebName,WebType,WebURL) 
                           VALUES(@WebID,@WebName,@WebType,@WebURL)";
             SqlCommand cmd = new SqlCommand(sql, myConn);
             
             
             try
             {
                //執行新增
                cmd.Parameters.AddWithValue("@WebID", count);
                cmd.Parameters.AddWithValue("@WebName", WebName);
                cmd.Parameters.AddWithValue("@WebType", WebType);
                cmd.Parameters.AddWithValue("@WebURL", WebURL);
                DataTable dt2 = new DataTable();
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
             return  "新增資料成功!";
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
            string sql = "SELECT COUNT(WebName) FROM WebData";
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