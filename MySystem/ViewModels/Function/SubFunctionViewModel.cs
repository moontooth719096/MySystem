﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySystem.ViewModels.Function
{
    
    public class SubFunctionViewModel
    {
        /// <summary>
        /// 功能代號
        /// </summary>
        public string SubFunctionID { get; set; }
        /// <summary>
        /// 功能英文名稱
        /// </summary>
        public string SubFunctionENName { get; set; }
        /// <summary>
        /// 功能中文名稱
        /// </summary>
        public string SubFunctionCNName { get; set; }
        /// <summary>
        /// 功能連結地址
        /// </summary>
        public string SubFunctionURL { get; set; }
        /// <summary>
        /// 功能類別
        /// </summary>
        public string SubFunctionType { get; set; }


    }
}