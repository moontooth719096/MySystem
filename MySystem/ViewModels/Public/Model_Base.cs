using ConnetDB.MySystemDB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MySystem.Models
{
    public class Model_Base
    {
        public SQLParameter sqlParameter;

        protected bool CheckDataTableExist(DataTable dt)
        {
            if (dt == null || dt.Rows.Count < 0)
                return false;
            return true;
        }
    }
}