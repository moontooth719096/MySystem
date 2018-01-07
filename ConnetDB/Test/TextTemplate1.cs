
using System;
using System.ComponentModel.DataAnnotations;

//todo: 請修改對應的namespace
namespace ConnetDB.Models
{        
             
	//mapping table name: TB_Calendar
	public class TB_Calendar                            
	{
		 [Display(Name="ID")]                        
	   public Int64 ID  { get; set; }
	    [Display(Name="EventName")]                        
	   public String EventName  { get; set; }
	    [Display(Name="Description")]                        
	   public String Description  { get; set; }
	    [Display(Name="EventTime")]                        
	   public DateTime EventTime  { get; set; }
	    [Display(Name="CreateDate")]                        
	   public DateTime CreateDate  { get; set; }
	                                   
	}                            
}