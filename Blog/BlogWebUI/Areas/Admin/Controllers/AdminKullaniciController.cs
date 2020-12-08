using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BlogBusiness.Abstract;
using BlogEntities.Concreate;
using BlogWebUI.Areas.Admin.Helper;
using BlogWebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogWebUI.Areas.Admin.Controllers
{
    [Area("admin")]
    public class AdminKullaniciController : Controller

    {
        IKullaniciServis _kullaniciServis;
        IRolServis _rolServis;
        public ResimKaydet _resimKaydet;
        public AdminKullaniciController(IKullaniciServis kullaniciServis = null, IRolServis rolServis = null)
        {
            _kullaniciServis = kullaniciServis;
            _rolServis = rolServis;

        }

        public IActionResult index()
        {
            var model = new AdminKullaniciViewModel();
            model.KulId = HttpContext.Session.GetInt32("id");
            model.Roller = _rolServis.RolleriGetir();
            model.Kullanicilar = _kullaniciServis.KullanicilariGetir();
            return View(model);

        }
   [HttpGet]
        public IActionResult Guncelle(int id)
        {
            var roller = _rolServis.RolleriGetir();
            var kullanici = _kullaniciServis.KullaniciGetir(id);
            SelectList datacombo = new SelectList(roller, "RolId", "RolAdi",kullanici.RolId);
            var   model = new AdminKullaniciViewModel()
            {
                SelectedRolId = kullanici.RolId,
                SelectedRolData = datacombo,
                Kullanici = kullanici
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Guncelle(int KullaniciId, string KulAdSoyad, string Email, string Parola, IFormFile FotoUrl, int RolId)
        {
            string FotoAdi;
            _resimKaydet = new ResimKaydet();
            if (FotoUrl==null)
            {
               var kul= _kullaniciServis.KullaniciGetir(KullaniciId);
               FotoAdi =kul.FotoUrl;
                if (ModelState.IsValid)
                {
                    Kullanici kullanici = new Kullanici
                    {
                        KullaniciId = KullaniciId,
                        KulAdSoyad = KulAdSoyad,
                        Email = Email,
                        FotoUrl = FotoAdi,
                        Parola = Parola,
                        RolId = RolId
                    };
                    _kullaniciServis.Guncelle(kullanici);

                    ViewBag.GuncellendiMi = true;
                }
            }
            if (FotoUrl != null)
            {
                var resimUrl = _resimKaydet.Yukle(FotoUrl,"Kullanici");
                if (ModelState.IsValid)
                {
                    Kullanici kullanici = new Kullanici {
                        KullaniciId=KullaniciId,
                        KulAdSoyad=KulAdSoyad,
                        Email=Email,
                        FotoUrl=resimUrl,
                        Parola=Parola,
                        RolId=RolId
                        };
                    _kullaniciServis.Guncelle(kullanici);

                    ViewBag.GuncellendiMi = true;
                }
            }
            return RedirectToAction("index", "AdminKullanici");
        }
        [HttpPost]
        public IActionResult Sil(int id)
        {
            if (ModelState.IsValid)
            {
                _kullaniciServis.Sil(id);

                ViewBag.silindiMi = true;
            }
            return RedirectToAction("index", "AdminKullanici");


        }

    }
}
