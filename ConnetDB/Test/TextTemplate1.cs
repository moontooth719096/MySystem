
using System;
using System.ComponentModel.DataAnnotations;

//todo: 請修改對應的namespace
namespace ConnetDB.Models
{        
		             
			//mapping table name: WebData
			public class WebData                            
			{
				[Display(Name="WebID")]                        
				public Int32 WebID  { get; set; }                                        
					
				[Display(Name="WebName")]                        
				public String WebName  { get; set; }                                        
					
				[Display(Name="WebType")]                        
				public String WebType  { get; set; }                                        
					
				[Display(Name="WebURL")]                        
				public String WebURL  { get; set; }                                        
					
				                                
			}                            
			}