using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BlogBusiness.Abstract;
using BlogEntities.Concreate;
using BlogWebUI.Areas.Admin.Helper;
using BlogWebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace BlogWebUI.Areas.Admin.Controllers
{
    [Area("admin")]
    public class AdminKategoriController : Controller
    {
        IKategoriServis _kategoriServis;
        private readonly IFileProvider _fileProvider;
      ResimKaydet _resimKaydet;
        public AdminKategoriController(IKategoriServis kategoriServis, IFileProvider fileProvider)
        {
            _kategoriServis = kategoriServis;
            _fileProvider = fileProvider;
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
        public string Upload(IFormFile file)
        {
            
            return "";
        }
        [HttpPost]
        public async Task<IActionResult> KategoriOlustur(string KategoriAdi, string KategoriAciklama, IFormFile KategoriImg)
        {
            if (ModelState.IsValid)
            {

                 _resimKaydet = new ResimKaydet();
                   var resim=_resimKaydet.Yukle(KategoriImg,"Kategori");

                    if (KategoriAdi != null)
                    {
                        Kategori kategori = new Kategori
                        {
                            KategoriAdi = KategoriAdi,
                            KategoriAciklama = KategoriAciklama,
                            KategoriImg =resim
                        };
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
                if (id==null)
                {
                    ViewBag.silindiMi = false;
                }
                _kategoriServis.Sil(id);
                ViewBag.silindiMi = true;
            }
            return RedirectToAction("index","AdminKategori");
        
        }
    }
}
