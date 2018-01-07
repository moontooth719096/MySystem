using System.Collections.Generic;
using System.Data;
using ConnetDB.MySystemDB;
using MySystem.Models.Function;
using System;
using MySystem.Models.Account;
using System.Linq;
using MySystem.Models.Management;
using MySystem.ViewModels.Management;

namespace MySystem.ViewModels.Function
{
    public class SidePageViewModel : ModelBase
    {
        public string Message="";

        /// <summary>
        /// 主功能清單
        /// </summary>
        public List<MainFunctionModel> MainFunctionList = new List<MainFunctionModel>();
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
            MainFunctionDT = mainfunctionDB.getData();
            foreach (DataRow dr in MainFunctionDT.Rows)
            {
                MainFunctionModel Data = new MainFunctionModel();
                Data.MainFunctionID = Convert.ToInt32(dr["MainFunctionID"]);
                Data.MainFunctionName = dr["MainFunctionName"].ToString();
                MainFunctionList.Add(Data);
            }
        }
        //取得子功能清單
        public string getSubFunctionList()
        {
            SubFunctionDB subfunctionDB = new SubFunctionDB();
            DataTable MainFunctionDT = new DataTable();
            MainFunctionDT = subfunctionDB.getData();
            if (CheckDataTableIsError(MainFunctionDT))
            {
                return MainFunctionDT.Rows[0]["msg"].ToString();
            }
            foreach (DataRow dr in MainFunctionDT.Rows)
            {
                SubFunctionViewModel Data = new SubFunctionViewModel();
                Data.SubFunctionID = dr["SubFunctionID"].ToString();
                Data.SubFunctionENName = dr["SubFunctionENName"].ToString();
                Data.SubFunctionCNName = dr["SubFunctionCNName"].ToString();
                Data.SubFunctionURL = dr["SubFunctionURL"].ToString();
                Data.MainFunctionType = Convert.ToInt32(dr["MainFunctionType"]);
                SubFunctionList.Add(Data);
            }

            return null;
        }
    }
}