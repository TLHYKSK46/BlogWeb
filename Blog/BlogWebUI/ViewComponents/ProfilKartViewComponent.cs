using BlogBusiness.Abstract;
using BlogWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebUI.ViewComponents
{
    public class ProfilKartViewComponent : ViewComponent
    {
        IKullaniciServis _kullaniciServis;

        public ProfilKartViewComponent(IKullaniciServis kullaniciServis)
        {
            _kullaniciServis = kullaniciServis;
        }

        public ViewViewComponentResult Invoke()
        {
            var superAdmin = _kullaniciServis.KullanicilariGetir();
            var model = new ProfilViewModel
            {
                SuperAdmin = superAdmin

            };

            return View(model);
        }
    }
}
