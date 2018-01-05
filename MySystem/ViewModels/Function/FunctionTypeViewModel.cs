using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySystem.ViewModels.Function
{
    public class FunctionTypeViewModel
    {
        /// <summary>
        /// 功能類別代號
        /// </summary>
        public string FunctionTypeID { get; set; }
        /// <summary>
        /// 功能類別英文名稱
        /// </summary>
        public string FunctionTypeENName { get; set; }
        /// <summary>
        /// 功能類別中文名稱
        /// </summary>
        public string FunctionTypeCNName { get; set; } 
    }
}