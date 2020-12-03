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


            //Kategori kategori = new Kategori
            //{

            //};

            //foreach (var item in kategoriler)
            //{
            //    SelectList katId = new SelectList(item.KategoriId.ToString());
            //    SelectList katadi = new SelectList(item.KategoriAdi);
            //}

            AdminMakaleViewModel model = new AdminMakaleViewModel
            {
                Kategoriler = kategoriler,
                Makaleler = makaleler,
                RolId = (int)HttpContext.Session.GetInt32("rolid"),
                KulId = (int)HttpContext.Session.GetInt32("id"),
                selectValue = datacombo

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
                SelectedKatData = datacombo


            };
            return View(model);
        }
        //[HttpPost]
        //public IActionResult MakaleOlustur(AdminComboViewModel model)
        //{
        //    var kategoriler = _kategoriServis.KategorileriGetir();
        //    SelectList datacombo = new SelectList(kategoriler, "KategoriId", "KategoriAdi");
        //    model.SelectedKatData = datacombo;
        //    return View(model);
        //}
        [HttpPost]
        public IActionResult MakaleOlustur(string makaleBaslik, string makaleIcerik, string makaleFotoUrl, int kategoriId)
        {
            var kategoriler = _kategoriServis.KategorileriGetir();
            SelectList datacombo = new SelectList(kategoriler, "KategoriId", "KategoriAdi");
            //kategoriId = datacombo.Where(x=>x.Value));
            var kulId = HttpContext.Session.GetInt32("id");
            if (!makaleBaslik.Equals(null) && !makaleIcerik.Equals(null) && !kategoriId.Equals(null) && !kulId.Equals(null))
            {
                Makale makale = new Makale
                {
                    KategoriId = kategoriId,
                    KullaniciId = kategoriId,
                    MakaleBaslik = makaleBaslik,
                    MakaleFotoUrl = makaleFotoUrl,
                    MakaleIcerik = makaleIcerik,
                    MakaleOkunmaSayisi = 0,
                    MakaleYayinlanmaTarihi = DateTime.Now
                };


                _makaleServis.Ekle(makale);
            }



            return View();
        }

        public IActionResult MakaleDüzenle(Makale makale)
        {
            //Makale makaleOkunmaSayisi = makaleler.First(u => u.MakaleId == ID);
            //makaleOkunmaSayisi.MakaleOkunmaSayisi += 1;
            //_makaleServis.Guncelle(makaleOkunmaSayisi);
            return View();
        }
        public IActionResult MakaleSil(int id)
        {
            _makaleServis.Sil(id);
            return View();
        }
    }
}
