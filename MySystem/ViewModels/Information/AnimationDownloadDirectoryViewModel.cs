using HtmlAgilityPack;
using MySystem.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Mvc;
using System.Xml;

namespace MySystem.ViewModels.Information
{
    public class AnimationDownloadDirectoryViewModel
    {
        public int SelectPage { get; set; }
        public string SelectName { get; set; }
        public List<string> SelectAnimation { get; set; }

        public List<AnimationDownloadDirectoryModel> AnimationList;
        /// <summary>
        /// 貨幣種類
        /// </summary>
        public IEnumerable<SelectListItem> Animation_Select
        {
            get
            {
                List<SelectListItem> mySelectItemList = new List<SelectListItem>();
                mySelectItemList.Add(new SelectListItem() { Text = "ALL", Value = "ALL" });
                SetAnimationALL();
                foreach (var data in SelectAnimation)
                {
                    mySelectItemList.Add(new SelectListItem() { Text = data, Value = data });
                }
                return mySelectItemList;
            }
        }
        public void init()
        {
            this.SelectPage = this.SelectPage == 0 ? 10 : this.SelectPage;
            this.SelectName = string.IsNullOrEmpty(this.SelectName) ? "ALL" : this.SelectName;
        }

        public void SetAnimationALL()
        {
            SelectAnimation = new List<string>();
            SelectAnimation.Add("BEATLESS");
            SelectAnimation.Add("皇帝聖印戰記");
            SelectAnimation.Add("黑色五葉草");
            SelectAnimation.Add("東京喰種re");
            SelectAnimation.Add("食戟之靈餐之皿");
            SelectAnimation.Add("我的英雄學院");
            SelectAnimation.Add("命運石之門");
            SelectAnimation.Add("刀剑神域");
        }

        public void SetNowselect()
        {
            if (SelectName.ToUpper() != "ALL")
            {
                SelectAnimation = new List<string>();
                SelectAnimation.Add(SelectName);
            }
            else
            {
                SetAnimationALL();
            }
            
        }

        public string GetAnimationList()
        {
            string message = string.Empty;
            //指定來源網頁
            using(WebClient url = new WebClient())
            {
                AnimationList = new List<AnimationDownloadDirectoryModel>();
                //將網頁來源資料暫存到記憶體內
                for (int i = 1; i <= SelectPage; i++)
                {
                    string Path = string.Empty;
                    if (this.SelectName.ToUpper() == "ALL")
                        Path = @"https://share.dmhy.org/topics/list/page/" + i;
                    else
                    {
                        Path = "https://share.dmhy.org/topics/list?keyword=" + this.SelectName;
                    }
                    using (MemoryStream ms = new MemoryStream(url.DownloadData(Path)))
                    {
                        HtmlDocument doc = new HtmlDocument();
                        try
                        {
                            doc.Load(ms, Encoding.UTF8);
                            if (doc.DocumentNode != null)
                            {
                                AnimationDownloadDirectoryModel Data;
                                
                                HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes(@"/html/body/div[1]/div[1]//div[2]/div[8]/div[2]/table[1]/tbody[1]/tr");
                                foreach(HtmlNode nodetr in nodes)
                                {
                                    if (SelectAnimation != null)
                                    {
                                        bool have = false;
                                        if (SelectName.ToUpper() == "ALL")
                                        {
                                            foreach (var data in SelectAnimation)
                                            {
                                                if (nodetr.SelectSingleNode("td[3]/a").InnerText.IndexOf(data) >= 0)
                                                {
                                                    have = true;
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            have = true;
                                        }
                                        if (have)
                                        {
                                            Data = new AnimationDownloadDirectoryModel();
                                            Data.Page = i;
                                            Data.AnimationName = nodetr.SelectSingleNode("td[3]/a").InnerText.Replace("\n", "").Replace("\t", "");
                                            Data.Url = "https://share.dmhy.org" + nodetr.SelectSingleNode("td[3]/a").Attributes[0].Value;
                                            //Data.Url = 
                                            AnimationList.Add(Data);
                                        }
                                        
                                    }
                                    
                                }
                            }
                            if (AnimationList == null || AnimationList.Count <= 0)
                                return "查無資料";
                        }
                        catch (Exception ex)
                        {
                            message = ex.Message.ToString();
                            return message;
                        }
                        finally
                        {
                            //清除資料
                            doc = null;
                        }
                    }
                }
            }
            return null;
        }
    }
    
}