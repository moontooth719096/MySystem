using ConnetDB.MySystemDB;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MySystem.Models.Function
{
    public class CalendarModel
    {
        [Display(Name = "ID")]
        public Int64 ID { get; set; }

        [Display(Name = "EventName")]
        public String EventName { get; set; }

        [Display(Name = "Description")]
        public String Description { get; set; }

        [Display(Name = "EventTime")]
        public DateTime EventTime { get; set; }

        [Display(Name = "CreateDate")]
        public DateTime CreateDate { get; set; }  
    }
}