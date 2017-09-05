using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySystem.ViewModels.Function
{
    public class MainFunctionViewModel
    {
            /// <summary>
        /// 功能代號
        /// </summary>
        public string MainFunctionID { get; set; }
        /// <summary>
        /// 功能名稱
        /// </summary>
        public string MainFunctionName { get; set; }
        /// <summary>
        /// 功能類別
        /// </summary>
        public string MainFunctionType { get; set; }
    }
}