using System.Data;

namespace MySystem.Models.Account
{
    public class ModelBase
    {
        protected bool CheckDataTableIsError(DataTable dt)
        {
            if (dt.Columns.Contains("Code"))
            {
                if (dt.Rows[0]["Code"].ToString() == "-99")
                    return true;
            }
            return false;
        }
    }
}