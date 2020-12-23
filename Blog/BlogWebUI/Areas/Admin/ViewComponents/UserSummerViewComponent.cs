using BlogWebUI.Areas.Admin.Attributes;
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
    public class UserSummerViewComponent : ViewComponent

    {
        public string AdSoyad { get; internal set; }
        public string Email { get; internal set; }
        public int RolId { get; internal set; }
        public string FotoUrl { get; internal set; }
        public GirisBilgisi _girisBilgileri=new GirisBilgisi();

        public ViewViewComponentResult Invoke()
        {

            //List<AdminKullaniciViewModel> viewModels = new List<AdminKullaniciViewModel>();

            //foreach (var item in viewModels)
            //{

            //    Kullanici kullanici = new Kullanici
            //    {
            //        Email = item.Email,
            //        FotoUrl = item.FotoUrl,
            //        KulAdSoyad = item.AdSoyad,
            //        RolId = item.RolId
            //    };
            //    return View(kullanici);
            //}
            AdSoyad = HttpContext.Session.GetString("adsoyad");
            Email = HttpContext.Session.GetString("email");
            RolId = (int)HttpContext.Session.GetInt32("rolid");
            FotoUrl = HttpContext.Session.GetString("fotourl");

            //_girisBilgileri.adsoyad = HttpContext.Session.GetString("adsoyad");
            //_girisBilgileri.email = HttpContext.Session.GetString("email");
            //_girisBilgileri.rolid = (int)HttpContext.Session.GetInt32("rolid");
            //_girisBilgileri.fotourl = HttpContext.Session.GetString("fotourl");
            //if (_girisBilgileri.adsoyad==null || _girisBilgileri.email== null|| _girisBilgileri.rolid ==null|| _girisBilgileri.fotourl ==null)
            //{
            //    RedirectResult redirect = new RedirectResult(url: "/Admin/AdminGiris/index");
            //    //context.HttpContext.Response.Redirect("/Giris/Kontrol");
            //    HttpContext.Response.Redirect("");


            //}
            AdminUserSummerViewCompenentModel model = new AdminUserSummerViewCompenentModel
            {
                AdSoyad = AdSoyad,
                Email = Email,
                FotoUrl = FotoUrl,
                RolId = RolId

            };
            return View(model);

        }
    }
}
