using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogBusiness.Abstract;
using BlogEntities.Concreate;
using BlogWebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebUI.Areas.Admin.Controllers
{

    public class AdminKullaniciController : Controller

    {
        IKullaniciServis _kullaniciServis;
        IRolServis _rolServis;
        public AdminKullaniciController(IKullaniciServis kullaniciServis = null, IRolServis rolServis = null)
        {
            _kullaniciServis = kullaniciServis;
            _rolServis = rolServis;

        }

        public IActionResult index()
        {

            var model = new AdminKullaniciViewModel();

            //model.Roller = _rolServis.RolleriGetir();
            model.Kullanicilar = _kullaniciServis.KullanicilariGetir();
            return View(model);

        }
        public IActionResult Guncelle(int Id)
        {
            //var model = new AdminKullaniciViewModel();
            //var kullanici = _kullaniciServis.KullanicilariGetir();
            //foreach (var item in kullanici)
            //{
            //    model.Kullanici=item
            //}

            AdminKullaniciViewModel model = new AdminKullaniciViewModel()
            {
                //Kullanici = _kullaniciServis.KullaniciGetir(Id)

            };
            return View(model);


        }
        [HttpPost]
        public IActionResult Guncelle(Kullanici kullanici)
        {

            if (ModelState.IsValid)
            {
                _kullaniciServis.Guncelle(kullanici);
                TempData.Add("mesaj", "Kullanici Başarıyla Guncellendi!");
            }
            return RedirectToAction("Guncelle");


        }

    }
}
