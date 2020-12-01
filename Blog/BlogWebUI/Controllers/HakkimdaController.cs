using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogBusiness.Abstract;
using BlogWebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebUI.Controllers
{
    public class HakkimdaController : Controller
    {
        IHakkimdaServis _hakkimdaServis;
        IKullaniciServis _kullaniciServis;


        public HakkimdaController(IHakkimdaServis hakkimdaServis, IKullaniciServis kullaniciServis)
        {
            _hakkimdaServis = hakkimdaServis;
            _kullaniciServis = kullaniciServis;
        }

        public IActionResult Index()
        {

            var hakkimda = _hakkimdaServis.HakkimdaGetir();
            var kullanici = _kullaniciServis.KullanicilariGetir();

            List<string> deneyimlerlist = new List<string>();
            List<string> becerilerlist = new List<string>();
            List<string> hobilerlist = new List<string>();
            List<string> egitimlerlist = new List<string>();
            List<string> odullerlist = new List<string>();
            foreach (var item in hakkimda)
            {
                becerilerlist = SplitList(item.Beceriler);
                deneyimlerlist = SplitList(item.Deneyim);
                hobilerlist = SplitList(item.Hobiler);
                egitimlerlist = SplitList(item.Egitim);
                odullerlist = SplitList(item.Sertifika_Oduller);

            }
            HakkimdaModel model = new HakkimdaModel
            {

                Hakkimda = hakkimda,
                SuperAdmin = kullanici,
                Deneyimler = deneyimlerlist,
                Beceriler = becerilerlist,
                Hobiler = hobilerlist,
                Egitimler = egitimlerlist,
                Oduller = odullerlist
            };
            return View(model);
        }
        public List<string> SplitList(string kayit)
        {
            List<string> splitListe = new List<string>();
            string[] liste = kayit.Split(',');//virgüle göre ayırıcak cümleyi
            foreach (var list in liste)
            {
                splitListe.Add(list.ToString());
            }
            return splitListe;
        }

    }
}
