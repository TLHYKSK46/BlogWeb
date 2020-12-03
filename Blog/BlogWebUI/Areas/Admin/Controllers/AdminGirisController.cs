using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogBusiness.Abstract;
using BlogEntities.Concreate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebUI.Areas.Admin.Controllers
{
    [Area("admin")]
    public class AdminGirisController : Controller
    {
        IKullaniciServis _kullaniciServis;

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



                    return Redirect("/Admin/AdminHome/index");

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
                return RedirectToAction("AdminGiris", "Admin");

            }
            return Redirect("/Admin/AdminGiris/KayitOl");


        }
    }
}
