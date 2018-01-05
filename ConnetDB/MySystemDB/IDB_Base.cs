using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnetDB.MySystemDB
{
    interface IDB_Base
    {
        #region 查詢
        /// <summary>
        /// 查詢
        /// </summary>
        /// <param name="Parameter">查詢條件</param>
        /// <returns></returns>
        DataTable getData(SQLParameter Parameter = null);
        #endregion
        string addData(SQLParameter Parameter);

        string editData(SQLParameter Parameter);

        string deleteDate(SQLParameter Parameter);
    }
}
