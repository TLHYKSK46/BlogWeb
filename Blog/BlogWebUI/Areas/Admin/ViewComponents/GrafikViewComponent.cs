using BlogBusiness.Abstract;
using BlogWebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebUI.Areas.Admin.ViewComponents
{
   
    public class GrafikViewComponent: ViewComponent
    {
        IMakaleServis _makaleServis;
        IKullaniciServis _kullaniciServis;
        IKategoriServis _kategoriServis;

        public GrafikViewComponent(IMakaleServis makaleServis, IKullaniciServis kullaniciServis, IKategoriServis kategoriServis)
        {
            _makaleServis = makaleServis;
            _kullaniciServis = kullaniciServis;
            _kategoriServis = kategoriServis;
        }

        public ViewViewComponentResult Invoke()
        {
            

            return View();
        }


        }
}
