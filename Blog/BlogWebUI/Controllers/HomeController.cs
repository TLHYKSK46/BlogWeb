using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BlogBusiness.Abstract;
using BlogEntities.Concreate;
using BlogWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BlogWebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IMakaleServis _makaleServis;
        IKategoriServis _kategoriServis;
        IKullaniciServis _kullaniciServis;
        IYorumServis _yorumServis;
        IHakkimdaServis _hakkimdaServis;
        IReferansServis _referansServis;
        IIletisimServis _iletisimServis;

        public HomeController(
            IMakaleServis makaleServis,
            IKullaniciServis kullaniciServis,
            IKategoriServis kategoriServis,
            IYorumServis yorumServis,
            ILogger<HomeController> logger, IHakkimdaServis hakkimdaServis, IReferansServis referansServis, IIletisimServis iletisimServis)
        {
            _yorumServis = yorumServis;
            _kullaniciServis = kullaniciServis;
            _kategoriServis = kategoriServis;
            _makaleServis = makaleServis;

            _logger = logger;
            _hakkimdaServis = hakkimdaServis;
            _referansServis = referansServis;
            _iletisimServis = iletisimServis;
        }

        public IActionResult Index(int sayfaNo = 1, int kategoriId = 0, String arananMetin = null)
        {
            int sayfaBoyut = 10;

            var makaleler = _makaleServis.MakaleleriGetir();

            var kategoriler = _kategoriServis.KategorileriGetir();
            var kullanicilar = _kullaniciServis.KullanicilariGetir();
            var yorumlar = _yorumServis.YorumlariGetir();


            if (arananMetin != null)
            {
                var makaleAra = makaleler.Where(i => i.MakaleBaslik.Contains(arananMetin) || (arananMetin == null)).OrderByDescending(m => m.MakaleYayinlanmaTarihi).ToList();
            }
            else
            {
                _makaleServis.MakaleleriGetir();
            }

            if (kategoriId.Equals(0)) { makaleler = _makaleServis.MakaleleriGetir(); }
            else { makaleler = _makaleServis.KategoriyeGoreGetir(kategoriId); }

            //----------------------------------------------------MOdel
            MakaleListViewModel model = new MakaleListViewModel
            {
                //MakaleAra=makaleAra,

                Makaleler = makaleler.Skip((sayfaNo - 1) * sayfaBoyut).Take(sayfaBoyut).ToList(),
                Kategoriler = kategoriler,
                Yorumlar = yorumlar,
                Kullanicilar = kullanicilar,
                seciliOlanKategori = Convert.ToInt32(HttpContext.Request.Query["KategoriId"]),
                SayfaSayisi = (int)Math.Ceiling(makaleler.Count / (double)sayfaBoyut),
                SayfaBoyut = sayfaBoyut,
                SeciliKategori = kategoriId,
                SeciliSayfa = sayfaNo
            };
            return View(model);
        }

        public IActionResult MakaleIcerik(int ID, int i = 0)
        {
            var yorumlar = _yorumServis.YorumlariGetir();
            var makaleler = _makaleServis.MakaleGetir(ID);
            var kategoriler = _kategoriServis.KategorileriGetir();
            var kullanicilar = _kullaniciServis.KullanicilariGetir();
            var seciliMakaleId = ID;
            MakaleListViewModel model = new MakaleListViewModel
            {
                SeciliMakaleId = seciliMakaleId,
                Kullanicilar = kullanicilar,
                Makaleler = makaleler,
                Kategoriler = kategoriler,
                Yorumlar = yorumlar
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult MakaleIcerik(int ID)
        {

            var yorumlar = _yorumServis.YorumlariGetir();
            var makaleler = _makaleServis.MakaleGetir(ID);
            var kategoriler = _kategoriServis.KategorileriGetir();
            var kullanicilar = _kullaniciServis.KullanicilariGetir();
            var seciliMakaleId = ID;
            Makale makaleOkunmaSayisi = makaleler.First(u => u.MakaleId == ID);
            makaleOkunmaSayisi.MakaleOkunmaSayisi += 1;
            _makaleServis.Guncelle(makaleOkunmaSayisi);
            MakaleListViewModel model = new MakaleListViewModel
            {
                SeciliMakaleId = seciliMakaleId,
                Kullanicilar = kullanicilar,
                Makaleler = makaleler,
                Kategoriler = kategoriler,
                Yorumlar = yorumlar
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult YorumEkle(Yorum yorum)
        {


            if (yorum.KullaniciId == 0)
            {
                yorum.KullaniciId = 1005;
            }

            YorumModelView model = new YorumModelView
            {
                Makaleicerik = this.MakaleIcerik
            };

            ///makaleid,
            yorum.YorumTarihi = DateTime.Now;
            _yorumServis.Ekle(yorum);
            //RedirectToAction("MakaleIcerik/{0}",yorum.MakaleId);
            return RedirectToAction("MakaleIcerik", new { ID = yorum.MakaleId });

        }
        [HttpGet]
        public IActionResult MakaleAra(string arananMetin = "11")
        {
            var makaleler = _makaleServis.MakaleleriGetir();


            var makaleAra = makaleler.Where(i => i.MakaleBaslik.Contains(arananMetin) || (arananMetin == null)).OrderByDescending(m => m.MakaleYayinlanmaTarihi).ToList();


            return View(makaleAra);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
