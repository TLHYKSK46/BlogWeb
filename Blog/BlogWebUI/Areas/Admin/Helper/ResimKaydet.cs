using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebUI.Areas.Admin.Helper
{
    public class ResimKaydet
    {

        public string Yukle(IFormFile file ,string gonderen)
        {
            string imageName="";
                string path="";
            
            if (file != null)
            {
                string imageExtension = Path.GetExtension(file.FileName);

                imageName = Guid.NewGuid() + imageExtension;
                if (gonderen.Equals("Kullanici"))
                {
                    path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/KulFoto/{imageName}");
                }
                if (gonderen.Equals("Makale"))
                {
                    path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/MakaleFoto/{imageName}");
                }
                if (gonderen.Equals("Kategori"))
                {
                    path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/KategoriFoto/{imageName}");
                }
                using var stream = new FileStream(path, FileMode.Create);

                file.CopyTo(stream);
                //await file.CopyToAsync(stream);
            }
            return imageName;
        }
       

    }
}
