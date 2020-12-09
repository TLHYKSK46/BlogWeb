using BlogBusiness.Abstract;
using BlogWebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebUI.Areas.Admin.ViewComponents
{
    public class BildirimViewComponent : ViewComponent
    {
        IBildirimServis _bildirimServis;
        IKullaniciServis _kullaniciServis;
        public BildirimViewComponent(IBildirimServis bildirimServis, IKullaniciServis kullaniciServis)
        {
            _bildirimServis = bildirimServis;
            _kullaniciServis = kullaniciServis;
        }

        public ViewViewComponentResult Invoke()
        {
            var KulId = HttpContext.Session.GetInt32("id");
            var bildirimler = _bildirimServis.BildirimleriGetir();
            var kullanici = _kullaniciServis.KullanicilariGetir();
            AdminBildirimViewModel model = new AdminBildirimViewModel();
            model.Bildirimler = bildirimler;
            model.KulId = KulId;
            model.Kullanicilar = kullanici;

            //foreach (var item in bildirimler)
            //{
            //    if (item.Gonderilen==KulId)
            //    {
            //       model = new AdminBildirimViewModel
            //        {
            //           Baslik=item.Baslik,
            //           Mesaj=item.Mesaj,
            //           Gonderen=item.Gonderen,
            //           Gonderilen=item.Gonderilen,
            //           GondermeTarihi=item.GondermeTarihi,
            //           Okundumu=item.Okundumu,
            //           Tur=item.Tur
                       
            //        };
            //    }
            //}
            return View(model);
        }
    }
}
