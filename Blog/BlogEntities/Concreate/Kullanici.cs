using BlogEntities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogEntities.Concreate
{
    public class Kullanici : IEntity
    {
        public int KullaniciId { get; set; }
        public string KulAdSoyad { get; set; }
        public string Email { get; set; }
        public string Parola { get; set; }
        public string FotoUrl { get; set; }
        public int RolId { get; set; }

    }
}
