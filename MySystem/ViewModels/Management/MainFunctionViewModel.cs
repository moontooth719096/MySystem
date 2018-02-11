using ConnetDB.MySystemDB;
using MySystem.Models;
using MySystem.Models.Management;
using MySystem.ViewModels.Public;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;

namespace MySystem.ViewModels.Management
{
    public class MainFunctionViewModel:Model_Base
    {
        public string Select_FunctionType { get; set; }
        /// <summary>
        /// 功能代號
        /// </summary>
        public int MainFunctionID { get; set; }
        /// <summary>
        /// 功能名稱
        /// </summary>
        public string MainFunctionName { get; set; }
        public string EditName { get; set; }

        public string Active { get; set; }

        #region 連接DB
        /// <summary>
        /// MainFunctionDB
        /// </summary>
        MainFunctionDB mainfunctionDB = new MainFunctionDB();
        SubFunctionDB subfunctionDB = new SubFunctionDB();
        #endregion

        public List<MainFunctionModel> MainFunctionList = new List<MainFunctionModel>();

        /// <summary>
        /// 儲存網頁類清單
        /// </summary>
        public IEnumerable<SelectListItem> Function_Select 
        { 
            get
            {
              List<SelectListItem> mySelectItemList = new List<SelectListItem>();
              mySelectItemList.Add(new SelectListItem() { Text = "主功能", Value = "0" });
              mySelectItemList.Add(new SelectListItem() { Text = "子功能", Value = "1" });
              if (!string.IsNullOrEmpty(Select_FunctionType))
              {
                  Select_FunctionType = "0";
              }
              return mySelectItemList;
            }
        }

        public string addMainFunction(string MainFunctionName)
        {
            sqlParameter = new SQLParameter();
            sqlParameter.SetActionValue.Add("MainFunctionName", MainFunctionName);
            return mainfunctionDB.addData(sqlParameter);
        }

        public string editMainFunction(string MainFunctionID)
        {
            sqlParameter = new SQLParameter();
            sqlParameter.SetActionValue.Add("MainFunctionName", this.MainFunctionName);
            sqlParameter.WhereCondition.Add("MainFunctionName", MainFunctionID);
            return mainfunctionDB.editData(sqlParameter);
        }

        public string deleteMainFunction()
        {
            sqlParameter = new SQLParameter();
            sqlParameter.WhereCondition.Add("MainFunctionID", MainFunctionID.ToString());
            return mainfunctionDB.deleteDate(sqlParameter);
        }

        #region 取得主功能清單
        public string getMainFunction()
        {
            sqlParameter = new SQLParameter();
            sqlParameter.OrderByValue = "MainFunctionID";
            DataTable dt = mainfunctionDB.getData(sqlParameter);
            if (CheckDataTableExist(dt) == false)
                return "查無資料!";
            MainFunctionList = (DataTableConvertToList.ToList<MainFunctionModel>(dt));
            sqlParameter = null;
            return null;
        }
        #endregion

        #region 取得子功能清單
        public string getSubFunction()
        {
            sqlParameter = new SQLParameter();
            sqlParameter.OrderByValue = "SubFunctionID";
            DataTable dt = subfunctionDB.getData(sqlParameter);
            if (CheckDataTableExist(dt) == false)
                return "查無資料!";
            MainFunctionList = (DataTableConvertToList.ToList<MainFunctionModel>(dt));
            sqlParameter = null;
            return null;
        }
        #endregion

        

    }
}