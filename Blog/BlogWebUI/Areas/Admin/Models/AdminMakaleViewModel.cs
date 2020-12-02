using BlogEntities.Concreate;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebUI.Areas.Admin.Models
{
    public class AdminMakaleViewModel
    {
        public List<Makale> Makaleler { get; internal set; }
        public int? RolId { get; internal set; }
        public int KulId { get; internal set; }
        public List<Kategori> Kategoriler { get; internal set; }
        //public List<Kategori> MobileList;
        public int selectListId { get; set; }
        public SelectList selectValue { get; internal set; }
    }
}
