using BlogEntities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogEntities.Concreate
{
    public class Referans : IEntity
    {
        [Key]
        public int ProjeId { get; set; }
        public string ProjeAdi { get; set; }
        public string ProjeTanim { get; set; }
        public string ProjedeKullanilanTeknolojiler { get; set; }
        public string ProjeFoto { get; set; }
        public DateTime ProjeTarih { get; set; }

    }
}
