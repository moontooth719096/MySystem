
using System;
using System.ComponentModel.DataAnnotations;

//todo: 請修改對應的namespace
namespace ConnetDB.Models
{        
             
	//mapping table name: TB_ExchangeRate
	public class TB_ExchangeRate                            
	{
		 [Display(Name="CurrencyID")]                        
	   public Int64 CurrencyID  { get; set; }
	    [Display(Name="CurrencyTypeName")]                        
	   public String CurrencyTypeName  { get; set; }
	    [Display(Name="CashBuyExchangeRate")]                        
	   public String CashBuyExchangeRate  { get; set; }
	    [Display(Name="CashSellExchangeRate")]                        
	   public String CashSellExchangeRate  { get; set; }
	    [Display(Name="SpotBuyExchangeRate")]                        
	   public String SpotBuyExchangeRate  { get; set; }
	    [Display(Name="SpotSellExchangeRate")]                        
	   public String SpotSellExchangeRate  { get; set; }
	    [Display(Name="CreateDate")]                        
	   public DateTime CreateDate  { get; set; }
	    [Display(Name="UpdateDate")]                        
	   public DateTime UpdateDate  { get; set; }
	                                   
	}                            
}