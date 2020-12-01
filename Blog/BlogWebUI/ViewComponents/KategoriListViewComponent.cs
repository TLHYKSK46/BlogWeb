using BlogBusiness.Abstract;
using BlogWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebUI.ViewComponents
{
    public class KategoriListViewComponent : ViewComponent
    {
        IKategoriServis _kategoriServis;
        IMakaleServis _makaleServis;

        public KategoriListViewComponent(IKategoriServis kategoriServis, IMakaleServis makaleServis)
        {
            _kategoriServis = kategoriServis;
            _makaleServis = makaleServis;
        }

        public ViewViewComponentResult Invoke()
        {
            var model = new KategoriListViewModel
            {
                Kategoriler = _kategoriServis.KategorileriGetir(),
                Makaleler = _makaleServis.MakaleleriGetir(),
                seciliOlanKategori = Convert.ToInt32(HttpContext.Request.Query["KategoriId"]),
            };

            return View(model);
        }


    }
}
