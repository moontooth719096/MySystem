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
            data.MP3 = "mp3/Christina Perri - A Thousand Years.mp3";
            data.Ogg ="";
            PlayMusicList = new List<PlayListModel>();
            PlayMusicList.Add(data);
            return null;
        }
    }
}