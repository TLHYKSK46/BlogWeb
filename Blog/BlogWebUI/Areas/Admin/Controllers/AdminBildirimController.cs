using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogBusiness.Abstract;
using BlogWebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebUI.Areas.Admin.Controllers
{
    [Area("admin")]
    public class AdminBildirimController : Controller
    {
        public IBildirimServis _bildirimServis;
        public IKullaniciServis _kullaniciServis;

        public AdminBildirimController(IBildirimServis bildirimServis, IKullaniciServis kullaniciServis)
        {
            _bildirimServis = bildirimServis;
            _kullaniciServis = kullaniciServis;
        }

        public IActionResult Index()
        {
            var bildirimler = _bildirimServis.BildirimleriGetir();
            var kullanici = _kullaniciServis.KullanicilariGetir();
            var model = new AdminBildirimViewModel();
            model.Bildirimler = bildirimler;
            model.Kullanicilar = kullanici;
            return View(model);
        }
       [HttpPost]
        public IActionResult BildirimDetay(int id=1){
            var bildirim = _bildirimServis.BildirimGetir(id);
            var bildirimler = _bildirimServis.BildirimleriGetir();
            var kullanici = _kullaniciServis.KullanicilariGetir();
         
            
            var model = new AdminBildirimViewModel();
            model.Bildirim = bildirim;

            model.Bildirimler = bildirimler;
            model.Kullanicilar = kullanici;

            return View(model);
        }
    }
}
