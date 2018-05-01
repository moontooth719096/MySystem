using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ConnetDB.MySystemDB
{
    public class TB_AnimationList : MySystemDB_Base
    {
        #region 取得我的動漫清單
        /// <summary>
        /// //取得我的最愛網頁資料
        /// </summary>
        /// <returns>回傳查出的資料</returns>
        public DataTable getAnimationList()
        {
            string sql = "SELECT * FROM TB_AnimationList";
            return QueryExcute(Conn, sql);
        }
        #endregion

        #region 新增我的動漫清單
        /// <summary>
        /// 新增我的動漫清單
        /// </summary>
        /// <param name="AnimationName">動漫名稱</param>
        /// <returns></returns>
        public int addWebdata(string AnimationName)
        {
            //先查詢目前筆數
            string sql = @"INSERT INTO TB_AnimationList
                           (AnimationName) 
                           VALUES(N'@AnimationName')";
            SqlCommand cmd = new SqlCommand(sql, Conn);
            //執行新增
            cmd.Parameters.AddWithValue("@AnimationName", AnimationName);
            DataTable dt2 = new DataTable();
            int count = cmd.ExecuteNonQuery();
            if (count > 0)
                return 1;
            else
                return -1;
        }
        #endregion


    }
}