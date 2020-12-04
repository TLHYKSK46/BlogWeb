using BlogEntities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebUI.Models
{
    public class MakaleListViewModel
    {
        public int seciliOlanKategori { get; internal set; }

        public List<Makale> Makaleler { get; internal set; }
        public List<Kullanici> Kullanicilar { get; internal set; }
        public List<Kategori> Kategoriler { get; internal set; }
        public int SayfaSayisi { get; internal set; }
        public int SayfaBoyut { get; internal set; }
        public int SeciliKategori { get; internal set; }
        public int SeciliSayfa { get; internal set; }
        public List<Makale> SliderMakale { get; internal set; }
        public int SeciliMakaleId { get; internal set; }
        public List<Yorum> Yorumlar { get; internal set; }
        public List<Makale> MakaleAra { get; internal set; }
        public Makale Makale { get; internal set; }
    }
}
