using MySystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MySystem.ViewModels.MusicPlayer
{
    public class MusicPlayerViewModel
    {
        public string Title {get;set;}
        public List<PlayListModel> PlayMusicList {get;set;}

        public string getMusicList()
        {
            PlayListModel data = new PlayListModel();
            data.Title = "A Thousand Years";
            data.Artist = "Christina Perri";
            data.Album = "A Thousand Years";
            data.Cover = "img/2.jpg";
            data.MP3 = @"C:\Users\伍國維\Desktop\新增資料夾\music\mp3\Acoustic Collabo - You And Me, Flutter";
            data.Ogg ="";
            PlayMusicList = new List<PlayListModel>();
            PlayMusicList.Add(data);

            data = new PlayListModel();
            data.Title = "云的舞蹈";
            data.Artist = "云的舞蹈";
            data.Album = "WanderLust";
            data.Cover = "img/6.jpg";
            data.MP3 = @"mp3/曹方 - 云的舞蹈.mp3";
            data.Ogg = "";
            PlayMusicList.Add(data);
            return null;
        }
    }
}