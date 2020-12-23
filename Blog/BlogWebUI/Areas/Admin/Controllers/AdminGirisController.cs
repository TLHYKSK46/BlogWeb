using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogBusiness.Abstract;
using BlogEntities.Concreate;
using BlogWebUI.Areas.Admin.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebUI.Areas.Admin.Controllers
{
    [Area("admin")]
    public class AdminGirisController : Controller
    {
        IKullaniciServis _kullaniciServis;
        //private GirisBilgisi _girisBiligisi=new GirisBilgisi();

        public AdminGirisController(IKullaniciServis kullaniciServis)
        {
            _kullaniciServis = kullaniciServis;
          
        }

        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Index(string email, string parola)
        {
            var sorgula = _kullaniciServis.KullanicilariGetir();
            foreach (var item in sorgula)
            {
                if (item.Email == email && item.Parola == parola)
                {
                    //AdminKullaniciViewModel model = new AdminKullaniciViewModel
                    //{
                    //    AdSoyad=item.KulAdSoyad,
                    //    Email=email,
                    //    RolId=item.RolId,
                    //    FotoUrl=item.FotoUrl

                    //};
                    HttpContext.Session.SetInt32("id", item.KullaniciId);
                    HttpContext.Session.SetString("adsoyad", item.KulAdSoyad);
                    HttpContext.Session.SetString("email", item.Email);
                    HttpContext.Session.SetString("fotourl", item.FotoUrl);
                    HttpContext.Session.SetInt32("rolid", item.RolId);
                //    List<GirisBilgisi> _girisBilgisi = new List<GirisBilgisi>();
                //    _girisBilgisi.Add(new GirisBilgisi() {

                //       Id = item.KullaniciId,
                //    RolId = item.RolId,
                //    Email = item.Email,
                //   FotoUrl = item.FotoUrl,
                //    Adsoyad = item.KulAdSoyad

                //});
                    //_girisBilgisi.Id = item.KullaniciId;
                    //_girisBilgisi.RolId = item.RolId;
                    //_girisBilgisi.Email = item.Email;
                    //_girisBilgisi.FotoUrl = item.FotoUrl;
                    //_girisBilgisi.Adsoyad = item.KulAdSoyad;

                    return RedirectToAction("index", "AdminHome");
                }
                else
                {
                }
            }

            return View();
        }

        public IActionResult KayitOl()
        {
            return View();
        }

        [HttpPost]
        public IActionResult KayitOl(string adsoyad, string email, string parola, string fotoUrl = "8.png")
        {
            Boolean sonuc = false;
            var sorgula = _kullaniciServis.KullanicilariGetir();
            foreach (var item in sorgula)
            {
                if (item.Email == email)
                {
                    sonuc = true;
                }
            }
            if (email != null && parola != null && adsoyad != null && sonuc == false)
            {
                Kullanici kullanici = new Kullanici
                {
                    KulAdSoyad = adsoyad,
                    Email = email,
                    Parola = parola,
                    RolId = 3,
                    FotoUrl = fotoUrl

                };
                _kullaniciServis.Ekle(kullanici);
                return RedirectToAction("index", "AdminGiris");
            }
            return RedirectToAction("KayitOl", "AdminGiris");
        }

        public IActionResult OturumKapat() {

            HttpContext.Session.Clear();

            return RedirectToAction("index", "AdminGiris");
        }

    }
}
