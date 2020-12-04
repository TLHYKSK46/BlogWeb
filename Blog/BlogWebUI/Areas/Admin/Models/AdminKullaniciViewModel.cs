using BlogEntities.Concreate;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebUI.Areas.Admin.Models
{
    public class AdminKullaniciViewModel
    {

        public List<Kullanici> Kullanicilar { get; internal set; }
        public List<Rol> Roller { get; internal set; }
        public Kullanici Kullanici { get; internal set; }
        public object KulId { get; internal set; }
        public string AdSoyad { get; internal set; }
        public int SelectedRolId { get; internal set; }
        public SelectList SelectedRolData { get; internal set; }
    }
}
