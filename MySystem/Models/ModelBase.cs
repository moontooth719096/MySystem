using System.Data;

namespace MySystem.Models.Account
{
    public class ModelBase
    {
        int Code { get; set; }
        string Message { get; set; }

        public ModelBase()
        {
            this.Code = 0;
            this.Message = string.Empty;
        }

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