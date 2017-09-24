using MySystem.Models.Function;
using MySystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;

namespace MySystem.ViewModels.Function
{
    public class SidePageViewModel
    {
        public string Message="";

        /// <summary>
        /// 主功能清單
        /// </summary>
        public List<MainFunctionViewModel> MainFunctionList = new List<MainFunctionViewModel>();
        /// <summary>
        /// 子功能清單
        /// </summary>
        public List<SubFunctionViewModel> SubFunctionList = new List<SubFunctionViewModel>();

        /// <summary>
        /// 取得主功能清單
        /// </summary>
        public void getMainFunctionList()
        { 
            MainFunctionDB mainfunctionDB = new MainFunctionDB();
            DataTable MainFunctionDT = new DataTable();
            MainFunctionDT = mainfunctionDB.QueryMainFunctionData();
            foreach (DataRow dr in MainFunctionDT.Rows)
            {
                MainFunctionViewModel Data = new MainFunctionViewModel();
                Data.MainFunctionID = dr["MainFunctionID"].ToString();
                Data.MainFunctionName = dr["MainFunctionName"].ToString();
                Data.MainFunctionType = dr["MainFunctionType"].ToString();
                MainFunctionList.Add(Data);
            }
        }
        //取得子功能清單
        public void getSubFunctionList()
        {
            /*SubFunctionViewModel Data = new SubFunctionViewModel();
            Data.SubFunctionID = "0";
            Data.SubFunctionENName = "LikeWeb";
            Data.SubFunctionCNName = "我的最愛網頁";
            Data.SubFunctionURL = "/LikeWeb/LikeWebMainPage";
            Data.SubFunctionType = "3";
            SubFunctionList.Add(Data);*/
            SubFunctionDB subfunctionDB = new SubFunctionDB();
            DataTable MainFunctionDT = new DataTable();
            MainFunctionDT = subfunctionDB.QuerySubFunctionData();
            foreach (DataRow dr in MainFunctionDT.Rows)
            {
                SubFunctionViewModel Data = new SubFunctionViewModel();
                Data.SubFunctionID = dr["SubFunctionID"].ToString();
                Data.SubFunctionENName = dr["SubFunctionENName"].ToString();
                Data.SubFunctionCNName = dr["SubFunctionCNName"].ToString();
                Data.SubFunctionURL = dr["SubFunctionURL"].ToString();
                Data.SubFunctionType = dr["SubFunctionType"].ToString();
                SubFunctionList.Add(Data);
            }
        }
    }
}