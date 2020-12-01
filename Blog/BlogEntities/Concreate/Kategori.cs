using BlogEntities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogEntities.Concreate
{
    public class Kategori : IEntity
    {
        public int KategoriId { get; set; }
        public string KategoriAdi { get; set; }
        public string KategoriAciklama { get; set; }
        public string KategoriImg { get; set; }

    }
}
