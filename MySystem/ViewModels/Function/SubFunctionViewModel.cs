using ConnetDB.MySystemDB;
using MySystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySystem.ViewModels.Function
{
    
    public class SubFunctionViewModel
    {
        /// <summary>
        /// 功能代號
        /// </summary>
        public string SubFunctionID { get; set; }
        /// <summary>
        /// 功能英文名稱
        /// </summary>
        public string SubFunctionENName { get; set; }
        /// <summary>
        /// 功能中文名稱
        /// </summary>
        public string SubFunctionCNName { get; set; }
        /// <summary>
        /// 功能連結地址
        /// </summary>
        public string SubFunctionURL { get; set; }
        /// <summary>
        /// 功能類別
        /// </summary>
        public int MainFunctionType { get; set; }

        //呼叫WebTypeDataDB
        MainFunctionDB mainfunctionDB;
        SubFunctionDB subfunctionDB;
        /// <summary>
        /// 儲存網業類清單
        /// </summary>
        public IEnumerable<SelectListItem> _MainFunctionList { get; set; }
        public string get_MainFunctionList()
        {
            mainfunctionDB = new MainFunctionDB();
            DataTable dt = mainfunctionDB.getData();
            List<SelectListItem> mySelectItemList = new List<SelectListItem>();
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    mySelectItemList.Add(new SelectListItem()
                    {
                        Text = dr["MainFunctionName"].ToString(),
                        Value = dr["MainFunctionID"].ToString(),
                        Selected = false
                    });
                }
                _MainFunctionList = mySelectItemList;
            }
            catch (Exception ex)
            {
                return ex.StackTrace.ToString();
            }
            return null;
        }

        public string addSubFunction()
        {
            subfunctionDB = new SubFunctionDB();
            string addSubFunctionMessage = subfunctionDB.addSubFunction(SubFunctionENName, SubFunctionCNName, SubFunctionURL, MainFunctionType);
            return addSubFunctionMessage;
        }
    }
}