using BlogEntities.Concreate;
using System;
using System.Collections.Generic;

namespace BlogWebUI.Areas.Admin.Models
{
    public class AdminBildirimViewModel
    {
       
        public List<Bildirim> Bildirimler { get; internal set; }
        public int? KulId { get; internal set; }
        public List<Kullanici> Kullanicilar { get; internal set; }
        public Bildirim Bildirim { get; internal set; }
    }
}