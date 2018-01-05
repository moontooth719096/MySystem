using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ConnetDB.MySystemDB
{
    public class WebDataDB : DB_Base
    {

        public WebDataDB()
        {
            string DBName = "MySystemDB";
            GetconnString(DBName);
        }

        #region 取得我的最愛網頁資料
        /// <summary>
        /// //取得我的最愛網頁資料
        /// </summary>
        /// <returns>回傳查出的資料</returns>
        public DataTable getWebdata()
        {
            string sql = "SELECT * FROM WebData";
            return QueryExcute(Conn, sql);
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
            DataTable GetCountDT = getWebdata();
            int count = 0;
            if(GetCountDT != null &&GetCountDT.Rows.Count >0)
              count = GetCountDT.Rows.Count;
            //先查詢目前筆數
            string sql = @"INSERT INTO WebData
                           (WebID,WebName,WebType,WebURL) 
                           VALUES(@WebID,@WebName,@WebType,@WebURL)";
            SqlCommand cmd = new SqlCommand(sql, Conn);
            //執行新增
            cmd.Parameters.AddWithValue("@WebID", count);
            cmd.Parameters.AddWithValue("@WebName", WebName);
            cmd.Parameters.AddWithValue("@WebType", WebType);
            cmd.Parameters.AddWithValue("@WebURL", WebURL);
            DataTable dt2 = new DataTable();
            cmd.ExecuteNonQuery();
            return "新增資料成功!";
        }
        #endregion


    }
}