using HtmlAgilityPack;
using MySystem.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace MySystem.ViewModels.Calculate
{
    public class ExchangeRateViewModel
    {
        public List<ExchangeRateModel> ExchangeRateList;

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
                if (doc.DocumentNode != null)
                {
                    ExchangeRateList = new List<ExchangeRateModel>();
                    ExchangeRateModel Data;
                    // 取得匯率 
                    for (int x = 1; x <= 21; x++)
                    {
                        Data = new ExchangeRateModel();
                        Data.CurrencyTypeName = doc.DocumentNode.SelectSingleNode(@"/html[1]/body[1]/div[1]/main[1]/div[4]/table[1]/tbody[1]/tr[" + x + "]/td[1]/div[1]/div[2]").InnerText.ToString().Replace("\r\n", "").Replace(" ", "");
                        Data.CashBuyExchangeRate = doc.DocumentNode.SelectSingleNode(@"/html[1]/body[1]/div[1]/main[1]/div[4]/table[1]/tbody[1]/tr[" + x + "]/td[2]").InnerText.ToString().Replace("\r\n", "").Replace(" ", "");
                        Data.CashSellExchangeRate = doc.DocumentNode.SelectSingleNode(@"/html[1]/body[1]/div[1]/main[1]/div[4]/table[1]/tbody[1]/tr[" + x + "]/td[3]").InnerText.ToString().Replace("\r\n", "").Replace(" ", "");
                        Data.SpotBuyExchangeRate = doc.DocumentNode.SelectSingleNode(@"/html[1]/body[1]/div[1]/main[1]/div[4]/table[1]/tbody[1]/tr[" + x + "]/td[4]").InnerText.ToString().Replace("\r\n", "").Replace(" ", "");
                        Data.SpotSellExchangeRate = doc.DocumentNode.SelectSingleNode(@"/html[1]/body[1]/div[1]/main[1]/div[4]/table[1]/tbody[1]/tr[" + x + "]/td[5]").InnerText.ToString().Replace("\r\n", "").Replace(" ", "");
                        ExchangeRateList.Add(Data);
                    }
                }
                if (ExchangeRateList == null || ExchangeRateList.Count <= 0)
                    return "查無資料";
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