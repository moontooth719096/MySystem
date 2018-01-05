using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConnetDB.MySystemDB
{
    public class SQLParameter
    {
       //要查詢的欄位
       //使用方法："ID,NAme,Age"
       //轉換成SQL語法: Select ID,NAme,Age
       public string SelectField { get; set; }
       //查詢條件 
       //使用方法: SQLParameter.WhereCondition.Add("ID",1);
       //轉換成SQL語法: Where ID = 1
       public Dictionary<string, string> WhereCondition = new Dictionary<string, string>();
       //設定值
       //使用方法: SQLParameter.WhereCondition.Add("ID",1);
       //轉換成SQL語法: Where ID = 1
       public Dictionary<string, object> SetActionValue = new Dictionary<string, object>();
       //EX: "ID,Name Desc" =  Order By ID,Name Desc
       public string OrderByValue { get; set; }
    }
}