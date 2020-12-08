using BlogEntities.Concreate;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace BlogWebUI.Areas.Admin.Models
{
    public class AdminKategoriViewModel
    {
        public List<Kategori> Kategori { get; internal set; }
   
        public IFormFile ProfileImage { get; set; }
    }
  
}
