using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogBusiness.Abstract;
using BlogEntities.Concreate;
using BlogWebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogWebUI.Areas.Admin.Controllers
{
    [Area("admin")]
    public class AdminMakaleController : Controller
    {
        IMakaleServis _makaleServis;
        IKategoriServis _kategoriServis;

        public AdminMakaleController(IMakaleServis makaleServis, IKategoriServis kategoriServis)
        {
            _makaleServis = makaleServis;
            _kategoriServis = kategoriServis;
        }

        public IActionResult Index()
        {
            var makaleler = _makaleServis.MakaleleriGetir();
            var kategoriler = _kategoriServis.KategorileriGetir();
            SelectList datacombo = new SelectList(kategoriler, "KategoriId", "KategoriAdi");
            AdminMakaleViewModel model = new AdminMakaleViewModel
            {
                Kategoriler = kategoriler,
                Makaleler = makaleler,
                RolId = (int)HttpContext.Session.GetInt32("rolid"),
                KulId = (int)HttpContext.Session.GetInt32("id"),
             

            };

            return View(model);
        }
      
        public IActionResult MakaleOlustur()
        {
            var kategoriler = _kategoriServis.KategorileriGetir();
            SelectList datacombo = new SelectList(kategoriler, "KategoriId", "KategoriAdi");
            AdminComboViewModel model = new AdminComboViewModel
            {
                SelectedKatId = 0,
                SelectedKatData = datacombo,
                //Kategoriler=kategoriler,
                //Makale=new Makale()
            };
            return View(model);
        }
      
        [HttpPost]
        public IActionResult MakaleOlustur(string makaleBaslik, string makaleIcerik, string makaleFotoUrl, int kategoriId)
        {
            var kulId = HttpContext.Session.GetInt32("id");
           
            if (!makaleBaslik.Equals(null) && !makaleIcerik.Equals(null) && !kategoriId.Equals(null) && !kulId.Equals(null))
            {
                Makale makale = new Makale
                {
                    KategoriId = kategoriId,
                    KullaniciId = Convert.ToInt32(kulId),
                    MakaleBaslik = makaleBaslik,
                    MakaleFotoUrl = makaleFotoUrl,
                    MakaleIcerik = makaleIcerik,
                    MakaleOkunmaSayisi = 0,
                    MakaleYayinlanmaTarihi = DateTime.Now
                };
                _makaleServis.Ekle(makale);
            }
            ViewBag.makaleYayinlandiMi = true;
            return RedirectToAction("index","AdminMakale");
        }

        [HttpGet]
        public IActionResult Guncelle(int id) {
            var kategoriler = _kategoriServis.KategorileriGetir();
            var makale = _makaleServis.MakaleGetir(id);
            SelectList datacombo = new SelectList(kategoriler, "KategoriId", "KategoriAdi",makale.KategoriId);
          
            int kategoriId = makale.KategoriId;
            var model = new AdminMakaleViewModel();
            model.Makale = makale;
            model.SelectedKatId =kategoriId;
            model.SelectedKatData = datacombo;
            return View(model);
        }

        [HttpPost]
        public IActionResult Guncelle(Makale makale)
        {
            if (ModelState.IsValid)
            {
                var mak = _makaleServis.MakaleGetir(makale.MakaleId);
                makale.MakaleOkunmaSayisi = mak.MakaleOkunmaSayisi;
                makale.KullaniciId = mak.KullaniciId;
                makale.MakaleId = mak.MakaleId;
                makale.MakaleYayinlanmaTarihi = mak.MakaleYayinlanmaTarihi;
                _makaleServis.Guncelle(makale);
                ViewBag.guncellendiMi = true;
            }
            return RedirectToAction("index","AdminMakale");
        }
        [HttpPost]
        public IActionResult MakaleSil(int id)
        {
            if (ModelState.IsValid)
            {
                _makaleServis.Sil(id);
                ViewBag.silindiMi = true;
            }
            return RedirectToAction("index", "AdminMakale");
        }
    }
}
