using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ConnetDB.MySystemDB
{
    public class MySystemDB_Base : DB_Base
    {
        public MySystemDB_Base()
        {
            string DBName = "MySystemDB";
            GetconnString(DBName);
        }
    }
}