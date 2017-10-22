using AutoMapper;
using ConnetDB.MySystemManagement;
using MySystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;

namespace MySystem.Models.LikeWeb
{
    public class WebDataModel
        
    { 
        /// <summary>
        /// 網頁ID
        /// </summary>
        public string WebID { get; set; }
        /// <summary>
        /// 網頁名稱
        /// </summary>
        public string WebName { get; set; }
        /// <summary>
        /// 網頁類型
        /// </summary>
        public string WebTypeNeme { get; set; }
        /// <summary>
        /// 網址
        /// </summary>
        public string WebURL { get; set; }
    }
}