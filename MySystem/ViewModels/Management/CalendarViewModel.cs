using ConnetDB.MySystemDB;
using MySystem.Models;
using MySystem.Models.Function;
using MySystem.ViewModels.Public;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MySystem.ViewModels.Management
{
    public class CalendarViewModel:Model_Base
    {
        public string Active { get; set; }
        public Int64  ID{ get; set; }
        public String EventName { get; set; }
        public String Description { get; set; }
        public String EventTime { get; set; }

        #region DB
        TB_Calendar_DB calendarDB;
        #endregion

        #region List
        public List<CalendarModel> CalendarList;
        #endregion

        public void init()
        {
            this.EventTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        }

        public string addCalendar()
        {
            DateTime Now = DateTime.Now;
            sqlParameter = new SQLParameter();
            sqlParameter.SetActionValue.Add("EventName", this.EventName);
            sqlParameter.SetActionValue.Add("Description", this.Description);
            sqlParameter.SetActionValue.Add("EventTime", this.EventTime);
            sqlParameter.SetActionValue.Add("CreateDate", Now);
            calendarDB = new TB_Calendar_DB();
            return calendarDB.addData(sqlParameter);
        }

        public string editCalendar(string MainFunctionName)
        {
            sqlParameter = new SQLParameter();
            sqlParameter.SetActionValue.Add("MainFunctionName", MainFunctionName);
            calendarDB = new TB_Calendar_DB();
            return calendarDB.editData(sqlParameter);
        }

        public string deleteCalendar(string ID)
        {
            sqlParameter = new SQLParameter();
            sqlParameter.WhereCondition.Add("ID", ID);
            calendarDB = new TB_Calendar_DB();
            return calendarDB.deleteDate(sqlParameter);
        }

        #region 取得主功能清單
        public string getCalendar()
        {
            sqlParameter = new SQLParameter();
            sqlParameter.OrderByValue = "EventTime Desc";
            calendarDB = new TB_Calendar_DB();
            DataTable dt = calendarDB.getData(sqlParameter);
            if (CheckDataTableExist(dt) == false)
                return "查無資料!";
            CalendarList = new List<CalendarModel>();
            CalendarList = (DataTableConvertToList.ToList<CalendarModel>(dt));
            sqlParameter = null;
            return null;
        }
        #endregion
    }
}