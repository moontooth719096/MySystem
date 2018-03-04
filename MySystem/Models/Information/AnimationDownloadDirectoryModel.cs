using HtmlAgilityPack;
using MySystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Mvc;
using System.Xml;

namespace MySystem.ViewModels.Information
{
    public class AnimationDownloadDirectoryModel
    {
        [Display(Name="動畫名稱")]
        public string AnimationName { get; set; }
        public string Url { get; set; }
        public int Page { get; set; }
    }
    
}