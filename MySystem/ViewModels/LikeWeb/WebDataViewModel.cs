using AutoMapper;
using ConnetDB.MySystemManagement;
using MySystem.Models;
using MySystem.Models.LikeWeb;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;

namespace MySystem.ViewModels.LikeWeb
{
    public class WebDataViewModel
        
    { 
        #region  連接DB用
        //呼叫WebDataDB
        WebDataDB _WebDataDB = new WebDataDB();
        //呼叫WebTypeDataDB
        WebTypeDataDB _WebTypeDataDB = new WebTypeDataDB();
        #endregion

        /// <summary>
        /// 網頁名稱
        /// </summary>
        public string WebName { get; set; }
        /// <summary>
        /// 網頁類型
        /// </summary>
        public string WebTypeNeme { get; set; }
        /// <summary>
        /// 網址
        /// </summary>
        public string WebURL { get; set; }
        /// <summary>
        /// 儲存網業類清單
        /// </summary>
        public IEnumerable<SelectListItem> _WebTypeList { get; set; }
        /// <summary>
        /// 儲存我的最愛網頁資訊
        /// </summary>
        public List<WebDataModel> WebDataList = new List<WebDataModel>();
        /// <summary>
        /// 儲存錯誤訊息
        /// </summary>
        public string Message;
        class dda
        {
            public string WebID { get; set; }
            public string WebName { get; set; }
            public string WebType { get; set; }
            public string WebURL { get; set; }
        }
        
        public void getWebdataDB()
        {
            try
            {
                DataTable dt = _WebDataDB.getWebdata();

                foreach (DataRow dr in dt.Rows)
                {
                    WebDataModel wdm = new WebDataModel();
                    wdm.WebID = dr["WebID"].ToString();
                    wdm.WebName = dr["WebName"].ToString();
                    wdm.WebTypeNeme = dr["WebType"].ToString();
                    wdm.WebURL = dr["WebURL"].ToString();
                    WebDataList.Add(wdm);
                }
            }
            catch(Exception ex)
            {
                Message = ex.StackTrace.ToString();
            }
        }

        public void getWebType()
        {
            DataTable dt = _WebTypeDataDB.getWebType();
            List<SelectListItem> mySelectItemList = new List<SelectListItem>();
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    mySelectItemList.Add(new SelectListItem()
                    {
                        Text = dr["WebTypeCNName"].ToString(),
                        Value = dr["WebTypeID"].ToString(),
                        Selected = false
                    });
                }
                _WebTypeList = mySelectItemList;
            }
            catch(Exception ex)
            {
                Message = ex.StackTrace.ToString();
            }
        }

        public string addWebdataDB(string WebName, string WebType, string WebURL)
        {

            Message = _WebDataDB.addWebdata(WebName, WebType, WebURL);
            if (string.IsNullOrEmpty(Message))
            { 
            
            }
            return null;
        }


    }
}