using MySystem.Models;
using MySystem.Models.Function;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySystem.ViewModels.Function
{
    public class MainFunctionViewModel
    {
            /// <summary>
        /// 功能代號
        /// </summary>
        public string MainFunctionID { get; set; }
        /// <summary>
        /// 功能名稱
        /// </summary>
        public string MainFunctionName { get; set; }
        /// <summary>
        /// 功能類別
        /// </summary>
        public string MainFunctionType { get; set; }

        #region 連接DB
        /// <summary>
        /// MainFunctionDB
        /// </summary>
        MainFunctionDB mainfunctionDB = new MainFunctionDB();
        //呼叫WebTypeDataDB
        WebTypeDataDB _WebTypeDataDB = new WebTypeDataDB();
        #endregion

        /// <summary>
        /// 儲存網業類清單
        /// </summary>
        public IEnumerable<SelectListItem> _WebTypeList { get; set; }

        public string addMainFunction(string MainFunctionName, string MainFunctionType)
        {
          return  mainfunctionDB.addMainFunction(MainFunctionName, MainFunctionType);
        }

        public string getWebType()
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
            catch (Exception ex)
            {
               return ex.StackTrace.ToString();
            }
            return null;
        }
    }
}