using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace MySystem.Models.Test
{
    public class Class1
    {
        public string Name { get; set;}
        public string Stust { get; set; }
        public string strResult { get; set; }
        public string Active { get; set; }
        public List<Class1> DataList { get; set; }

        public void getData()
        {
            DataList = new List<Class1>();
            Class1 data = new Class1();
            data.Name = "第一筆";
            data.Stust = "蘋果";
            DataList.Add(data);
            data = new Class1();
            data.Name = "第二筆";
            data.Stust = "香蕉";
            DataList.Add(data);
            data = new Class1();
            data.Name = "第三筆";
            data.Stust = "葡萄";
            DataList.Add(data);
        }

        public void GetWebContent(string Url)
        {
            strResult = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                request.Timeout = 30000;
                request.Headers.Set("Pragma", "no-cache");
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream streamReceive = response.GetResponseStream();
                Encoding encoding = Encoding.GetEncoding("UTF-8");
                StreamReader streamReader = new StreamReader(streamReceive, encoding);
                strResult = streamReader.ReadToEnd();

                //搜尋頭尾關鍵字, 搜尋方法見後記(1)
                int first = strResult.IndexOf("</h2>");
                int last = strResult.LastIndexOf(@"<p class");

                //減去頭尾不要的字元或數字, 並將結果轉為string. 計算方式見後記(2)
                string HTMLCut = strResult.Substring(first + 9, last - first - 9);
                strResult = HTMLCut;
            }
            catch (Exception e)
            {
                
            }
        }
    }
}