using BlogEntities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogEntities.Concreate
{
    public class Etiket : IEntity
    {
        public int EtiketId { get; set; }
        public string EtiketAdi { get; set; }


    }
}
