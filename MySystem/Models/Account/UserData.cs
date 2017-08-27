using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySystem.Models.Account
{
    public class UserData
    {
       public string UserAccount { get;set; }
       public string UserPassWord { get; set; }
       public string UserCompetence { get; set; }
       public DateTime UserBirthday { get; set; }
       public string UserEmail { get; set; }
       public string UserPhoneNumber { get; set; }
       public string UserGender { get; set; }
       public string UserAddress { get; set; }
       public DateTime CreatDateTime { get; set; }
       public DateTime ModifyDateTime { get; set; }
       public DateTime LoginDateTime { get; set; }
       private string _IsUse;
       public string IsUse
       {
           get { return this._IsUse; }
           set
           {
               if(value =="1")
               {
                   value = "true";
               }
               if(value =="0")
               {
                   value = "false";
               }
               this._IsUse = value;
           }
       }
       public string Memo { get; set; }

       public string getUserData()
       {
           return null;
       }

       public string creatUserData(UserData medol)
       {
           return null;
       }
       public string modifyUserData(UserData medol)
       {
           return null;
       }
    }
}