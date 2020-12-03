using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogBusiness.Abstract;
using BlogEntities.Concreate;
using BlogWebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebUI.Areas.Admin.Controllers
{
    [Area("admin")]
    public class AdminKategoriController : Controller
    {
        IKategoriServis _kategoriServis;

        public AdminKategoriController(IKategoriServis kategoriServis)
        {
            _kategoriServis = kategoriServis;
        }

        public IActionResult Index()
        {
            var kategori = _kategoriServis.KategorileriGetir();
            AdminKategoriViewModel model = new AdminKategoriViewModel
            {
                Kategori = kategori
            };

            return View(model);
        }
        public IActionResult KategoriOlustur() {


            return View();
        }
        [HttpPost]
        public IActionResult KategoriOlustur(Kategori kategori)
        {

            if (ModelState.IsValid)
            {
                _kategoriServis.Ekle(kategori);
                ViewBag.eklendiMi = true;

            }
            return RedirectToAction("index", "AdminKategori");
        }


        [HttpPost]
        public IActionResult Sil(int id)
        {
            if (ModelState.IsValid)
            {
                _kategoriServis.Sil(id);
                ViewBag.silindiMi = true;
            }
            return RedirectToAction("index","AdminKategori");
        
        }
    }
}
