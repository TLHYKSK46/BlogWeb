using BlogEntities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebUI.Areas.Admin.Models
{
    public class AdminKategoriViewModel
    {
        public List<Kategori> Kategori { get; internal set; }
    }
}
