using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogBusiness.Abstract;
using BlogEntities.Concreate;
using BlogWebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebUI.Controllers
{
    public class IletisimController : Controller
    {
        IIletisimServis _iletisimServis;

        public IletisimController(IIletisimServis iletisimServis)
        {
            _iletisimServis = iletisimServis;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(IletisimModelView model)
        {
            if (ModelState.IsValid)
            {
                Iletisim mail = new Iletisim
                {
                    AdSoyad = model.AdSoyad,
                    Email = model.Email,
                    Konu = model.Konu,
                    Mesaj = model.Mesaj,
                    OkunduMu = 0//0=okunmadı 1=okundu
                };

                _iletisimServis.Ekle(mail);
                var body = new StringBuilder();
                body.AppendLine("Ad Soyad: " + model.AdSoyad);
                body.AppendLine("E-Mail Adresi: " + model.Email);
                body.AppendLine("Konu: " + model.Konu);
                body.AppendLine("Mesaj: " + model.Mesaj);
                Mail.MailSender(body.ToString());
                ViewBag.MailGonderildiMi = true;
                //return RedirectToAction("Iletisim");
                return View();
            }
            else
            {
                return View();
            }
        }
    }
}
