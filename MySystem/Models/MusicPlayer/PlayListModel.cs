using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MySystem.Models
{
    public class PlayListModel
    {
       public string Title {get;set;}
       public string Artist{get;set;}
       public string Album {get;set;}
       /// <summary>
       /// 專輯封面路徑
       /// </summary>
       public string Cover {get;set;}
       /// <summary>
       /// MP3存放路徑
       /// </summary>
       public string MP3 {get;set;}
       public string Ogg {get;set;}
      
    }
}