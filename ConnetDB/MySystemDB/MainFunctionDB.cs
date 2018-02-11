using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace ConnetDB.MySystemDB
{
    public class MainFunctionDB : DB_Base, IDB_Base
    {
        string TBName = "MainFunctionData";
        public MainFunctionDB()
        {
            string DBName = "MySystemDB";
            GetconnString(DBName);
        }
        /// <summary>
        /// 查詢Tabel MainFunctionData
        /// </summary>
        /// <param name="Parameter"></param>
        /// <returns></returns>
        public DataTable getData(SQLParameter Parameter =null)
        {
            string SqlString = combinationQuerySQLString(Parameter, TBName);
            return QueryExcute(Conn, SqlString.ToString());
        }

        public string addData(SQLParameter Parameter)
        {
            StringBuilder SQLString = new StringBuilder();
            SQLString.Append(string.Concat("INSERT INTO "+TBName));
            SQLString.Append(" VALUES( ");
            string ConnetSetValue = string.Empty;
            foreach (var pa in Parameter.SetActionValue)
            {
                if (!string.IsNullOrEmpty(ConnetSetValue))
                     ConnetSetValue += ",";
                ConnetSetValue +=string.Concat("@"+pa.Key);
            }
            SQLString.Append(string.Concat(ConnetSetValue+" )"));
            ExcuteAction(Conn, SQLString.ToString(), Parameter);
            return null;
        }

        public string editData(SQLParameter Parameter)
        {
            StringBuilder SQLString = new StringBuilder();
            SQLString.Append(string.Concat("Update " + TBName));
            SQLString.Append(" Set ");
            string ConnetSetValue = string.Empty;
            foreach (var pa in Parameter.SetActionValue)
            {
                if (!string.IsNullOrEmpty(ConnetSetValue))
                    ConnetSetValue += ",";
                ConnetSetValue += string.Concat(pa.Key + " = " + "@" + pa.Key);
            }
            SQLString.Append(string.Concat(ConnetSetValue));
            SQLString.Append(@"Delete " + TBName + " Where 1=1");
            foreach (var pa in Parameter.WhereCondition)
            {
                SQLString.Append(string.Concat(" And " + pa.Key + " =" + pa.Value));
            }
            ExcuteAction(Conn, SQLString.ToString(), Parameter);
            return null;
        }

        public string deleteDate(SQLParameter Parameter)
        {
            StringBuilder SQLString = new StringBuilder();
            SQLString.Append(@"Delete "+ TBName+" Where 1=1");
            foreach(var pa in Parameter.WhereCondition) 
            {
             SQLString.Append(string.Concat(" And "+pa.Key +" ="+pa.Value));
            }
            bool Result = ExcuteAction(Conn, SQLString.ToString());
            if (Result)
                return "刪除成功!";
            else
                return "刪除失敗!";
        }
    }
}