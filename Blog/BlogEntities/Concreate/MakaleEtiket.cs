using BlogEntities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogEntities.Concreate
{
    public class MakaleEtiket : IEntity
    {
        public int MakaleId { get; set; }
        public int EtiketId { get; set; }
    }
}
