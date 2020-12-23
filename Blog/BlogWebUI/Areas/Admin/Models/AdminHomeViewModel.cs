using BlogEntities.Concreate;
using System.Collections.Generic;

namespace BlogWebUI.Areas.Admin.Models
{
    public class AdminHomeViewModel
    {
        public AdminHomeViewModel()
        {
        }

        public Makale Makale { get; internal set; }
        public Kullanici Kullanici { get; internal set; }
        public int MakSayisi { get; internal set; }
        public int KatMakaleSayisi { get; internal set; }
        public Kategori Kategori { get; internal set; }
    }
}