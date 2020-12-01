using BlogBusiness.Abstract;
using BlogDataAccess.Abstract;
using BlogEntities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogBusiness.Concreate
{
    public class YorumYonetici:IYorumServis
    {
        private IYorumDal _yorumDal;
        public YorumYonetici(IYorumDal yorumDal)
        {
            _yorumDal = yorumDal;
        }
        public void Ekle(Yorum Yorum)
        {
            _yorumDal.Ekle(Yorum);
        }

        public void Guncelle(Yorum Yorum)
        {
            _yorumDal.Guncelle(Yorum);
        }

        public void Sil(int id)
        {
            _yorumDal.Sil(new Yorum { MakaleId = id });
        }

        public List<Yorum> YorumGetir(int YorumId)
        {
            return _yorumDal.ListeGetir(p => p.YorumId == YorumId);
        }


        List<Yorum> IYorumServis.YorumlariGetir()
        {
            return _yorumDal.ListeGetir();
        }
    }
}
