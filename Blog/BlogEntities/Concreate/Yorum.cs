using BlogEntities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogEntities.Concreate
{
    public class Yorum : IEntity
    {
        public int YorumId { get; set; }
        public string Icerik { get; set; }
        public int KullaniciId { get; set; }
        public int MakaleId { get; set; }
        public DateTime YorumTarihi
        {
            get;
            set;
        }
    }
}
