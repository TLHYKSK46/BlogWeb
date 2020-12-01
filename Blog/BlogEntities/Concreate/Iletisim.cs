using BlogEntities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogEntities.Concreate
{
    public class Iletisim : IEntity
    {
        public int IletisimId { get; set; }
        public string AdSoyad { get; set; }
        public string Email { get; set; }
        public string Mesaj { get; set; }
        public string Konu { get; set; }
        public int OkunduMu { get; set; }


    }
}
