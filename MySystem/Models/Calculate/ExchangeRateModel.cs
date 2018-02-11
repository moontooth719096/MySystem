using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace MySystem.Models
{
    public class ExchangeRateModel
    {
        [Display(Name = "CurrencyID")]
        public Int64 CurrencyID { get; set; }
        [Display(Name = "貨幣種類")]
        public String CurrencyTypeName { get; set; }
        [Display(Name = "銀行買入價")]
        public String CashBuyExchangeRate { get; set; }
        [Display(Name = "銀行賣出價")]
        public String CashSellExchangeRate { get; set; }
        [Display(Name = "銀行買入價")]
        public String SpotBuyExchangeRate { get; set; }
        [Display(Name = "銀行賣出價")]
        public String SpotSellExchangeRate { get; set; }
        [Display(Name = "新增時間")]
        public DateTime CreateDate { get; set; }
        [Display(Name = "更新時間")]
        public DateTime UpdateDate { get; set; }

        public string GetExchangeRate()
        {
            //指定來源網頁
            WebClient url = new WebClient();
            //將網頁來源資料暫存到記憶體內
            MemoryStream ms = new MemoryStream(url.DownloadData("http://rate.bot.com.tw/Pages/Static/UIP003.zh-TW.htm"));
            //以台灣銀行為範例

            // 使用預設編碼讀入 HTML 
            HtmlDocument doc = new HtmlDocument();
            try
            {
                doc.Load(ms, Encoding.UTF8);

                // 取得匯率 
                for (int x = 1; x <= 21; x++)
                {
                    var txt1 = doc.DocumentNode.SelectSingleNode(@"/html[1]/body[1]/div[1]/main[1]/div[4]/table[1]/tbody[1]/tr[" + x + "]/td[1]/div[1]/div[2]").InnerText.ToString().Replace("\r\n", "").Replace(" ", "");
                    var txt2 = doc.DocumentNode.SelectSingleNode(@"/html[1]/body[1]/div[1]/main[1]/div[4]/table[1]/tbody[1]/tr[" + x + "]/td[2]").InnerText.ToString().Replace("\r\n", "").Replace(" ", "");
                    var txt3 = doc.DocumentNode.SelectSingleNode(@"/html[1]/body[1]/div[1]/main[1]/div[4]/table[1]/tbody[1]/tr[" + x + "]/td[3]").InnerText.ToString().Replace("\r\n", "").Replace(" ", "");
                    var txt4 = doc.DocumentNode.SelectSingleNode(@"/html[1]/body[1]/div[1]/main[1]/div[4]/table[1]/tbody[1]/tr[" + x + "]/td[4]").InnerText.ToString().Replace("\r\n", "").Replace(" ", "");
                    var txt5 = doc.DocumentNode.SelectSingleNode(@"/html[1]/body[1]/div[1]/main[1]/div[4]/table[1]/tbody[1]/tr[" + x + "]/td[5]").InnerText.ToString().Replace("\r\n", "").Replace(" ", "");
                    string totle = string.Format("幣別：{0} ，買入現金匯率：{1} ，賣出即期匯率：{2} ，買入遠期匯率：{3} ，賣出歷史匯率：{4}", txt1, txt2, txt3, txt4, txt5);
                }
                return null;
            }
            catch (Exception ex)
            {
                return "取得匯率錯誤!";
            }
            finally
            {
                //清除資料
                doc = null;
                url = null;
                ms.Close();
            }
        }
    }
    
}