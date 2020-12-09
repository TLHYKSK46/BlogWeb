using BlogEntities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogEntities.Concreate
{
   public class Bildirim:IEntity
    {
 
        public int id { get; set; }
        public string  Baslik  { get; set; }
        public string Mesaj { get; set; }
        public string Tur { get; set; }
        public bool Okundumu { get; set; }
        public string Mail { get; set; }
        public int Gonderen { get; set; }
        public int Gonderilen { get; set; }
        public DateTime GondermeTarihi { get; set; }

    }
}
