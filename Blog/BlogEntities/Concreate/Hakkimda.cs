using BlogEntities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogEntities.Concreate
{
    public class Hakkimda : IEntity
    {
        public int HakkimdaId { get; set; }
        public string Deneyim { get; set; }
        public string Egitim { get; set; }
        public string Beceriler { get; set; }
        public string Hobiler { get; set; }
        public string Sertifika_Oduller { get; set; }

    }
}
