using System;
using System.Collections.Generic;
using System.Linq;
using BlogBusiness.Abstract;
using BlogWebUI.Areas.Admin.Attributes;
using BlogWebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebUI.Areas.Admin.Controllers
{

    [Area("admin")]
 
    public class AdminHomeController : Controller
    {
        IMakaleServis _makaleServis;
        IKullaniciServis _kullaniciServis;
        IKategoriServis _kategoriServis;

       private string adsoyad, email, fotourl ;
       private int id, rolid;

        public AdminHomeController(IMakaleServis makaleServis, IKullaniciServis kullaniciServis, IKategoriServis kategoriServis)
        {
            _makaleServis = makaleServis;
            _kullaniciServis = kullaniciServis;
            _kategoriServis = kategoriServis;
        }

        [GirisKontrol]
        public IActionResult Index()
        {
         
            try
            {
                 id = (int)HttpContext.Session.GetInt32("id");
                 adsoyad = HttpContext.Session.GetString("adsoyad");
                 email = HttpContext.Session.GetString("email");
                 fotourl = HttpContext.Session.GetString("fotourl");
                 rolid = (int)HttpContext.Session.GetInt32("rolid");
            }
            catch (Exception)
            {
                if (id == null || adsoyad == null || email == null || fotourl == null || rolid == null)
                {
                    return RedirectToAction("index", "AdminGiris");
                }
            }

            var makaleler = _makaleServis.MakaleleriGetir();
            
            var kategoriler = _kategoriServis.KategorileriGetir();
         
            var maxOkunma = makaleler.Max(x=>x.MakaleOkunmaSayisi);
            var makale = makaleler.First(x=>x.MakaleOkunmaSayisi==maxOkunma);



            var grupKat = (from mak in makaleler
                           orderby mak.KategoriId
                           group mak by mak.KategoriId into kat
                           select new { kat = kat.Key, makaleSayisi = kat.Count() });
            int enbkatid = 0;
            int ilkatid = 0;
            int sonid = 0;
            int maksaykat = 0;
            foreach (var i in grupKat)
            {
                ilkatid = i.makaleSayisi;
                if (ilkatid > sonid)
                {
                    sonid = ilkatid;
                    enbkatid = i.kat;
                    maksaykat = i.makaleSayisi;
                }

            }

            var kategori = _kategoriServis.KategoriGetir(enbkatid);


            var grupKul = (from mak in makaleler
                           orderby mak.KullaniciId
                           group mak by mak.KullaniciId into kul
                           select new { kul = kul.Key, makaleSayisi = kul.Count() });

            //var maxKul = ent.makaleler.select(i.kullaniciid).max();
            int enbID = 0;
            int ilkd = 0;
            int sond = 0;
            int maksay =0;
             foreach(var i in grupKul)
            {
                ilkd = i.makaleSayisi;
                if (ilkd > sond)
                {
                    sond = ilkd;
                    enbID = i.kul;
                   maksay= i.makaleSayisi;
                }

            }

            var enbuyukId = enbID;
            
          var  kullanici = _kullaniciServis.KullaniciGetir(enbuyukId);
          

            AdminHomeViewModel model = new AdminHomeViewModel();
           model.Kullanici = kullanici;
            model.MakSayisi = maksay;
            model.Makale = makale;
            model.Kategori = kategori;
            model.KatMakaleSayisi = maksaykat; 
            //model.Kategori = kategori;



            return View(model);
        }
        [HttpGet]
        public JsonResult MakaleOkumaGrafik() {
            var makale = _makaleServis.MakaleleriGetir().Take(10);
            List<GrafikViewModel> GrafikViewModel = new List<GrafikViewModel>();
            GrafikViewModel.Add(new Models.GrafikViewModel { MakaleBaslik="Test1",OkunmaSayisi=100});
            GrafikViewModel.Add(new Models.GrafikViewModel { MakaleBaslik = "Test2", OkunmaSayisi = 100 });
            GrafikViewModel.Add(new Models.GrafikViewModel { MakaleBaslik = "Test3", OkunmaSayisi = 100 });
            GrafikViewModel.Add(new Models.GrafikViewModel { MakaleBaslik = "Test4", OkunmaSayisi = 100 });
            GrafikViewModel.Add(new Models.GrafikViewModel { MakaleBaslik = "Test5", OkunmaSayisi = 100 });

            //foreach (var item in makale)
            //{
            //    GrafikViewModel.Add(item);
            //}

            return Json(GrafikViewModel);
        }
    }
}
