using BlogEntities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogEntities.Concreate
{
    public class Makale : IEntity
    {
        public int MakaleId { get; set; }
        public string MakaleBaslik { get; set; }
        public string MakaleIcerik { get; set; }

        public string MakaleFotoUrl { get; set; }
        public int MakaleOkunmaSayisi { get; set; }
        public int KullaniciId { get; set; }
        public DateTime MakaleYayinlanmaTarihi { get; set; }
        public int KategoriId { get; set; }




    }
}
