using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BlogBusiness.Abstract;
using BlogEntities.Concreate;
using BlogWebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Http;
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
        [ValidateAntiForgeryToken]
        public IActionResult KategoriOlustur(Kategori kategori)
        {
            var files = HttpContext.Request.Form.Files;
            if (Request.Form.Files.Count>0)
            {
                //string dosyaAdi = Path.GetFileName(Request.Form.Files[0].FileName);
                //string uzanti = Path.GetExtension(Request.Form.Files[0].FileName);
                //string yol = "~/wwwroot/images/KategoriFoto/" + dosyaAdi + uzanti;
                //Request.Form.Files[0].ToString(yol);

            }

            //if (file != null)
            //{
            //    string imageExtension = Path.GetExtension(file.FileName);

            //    string imageName = Guid.NewGuid() + imageExtension;

            //    string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/KategoriFoto/{imageName}");

            //    using var stream = new FileStream(path, FileMode.Create);
            //    file.CopyTo(stream);
            //    //await file.CopyToAsync(stream);
            //}

            if (ModelState.IsValid)
            {
                if (kategori.KategoriAdi!=null)
                {
                    _kategoriServis.Ekle(kategori);
                    ViewBag.eklendiMi = true;
                }
               

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
