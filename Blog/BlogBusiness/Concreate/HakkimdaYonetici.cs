using BlogBusiness.Abstract;
using BlogDataAccess.Abstract;
using BlogEntities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogBusiness.Concreate
{
  public  class HakkimdaYonetici:IHakkimdaServis
    {
        private IHakkimdaDal _hakkimdaDal;
        public HakkimdaYonetici(IHakkimdaDal hakkimdaDal)
        {
            _hakkimdaDal = hakkimdaDal;

        }

        public void Ekle(Hakkimda Hakkimda)
        {
            _hakkimdaDal.Ekle(Hakkimda);
        }

        public void Guncelle(Hakkimda Hakkimda)
        {
            _hakkimdaDal.Guncelle(Hakkimda);
        }

        public List<Hakkimda> HakkimdaGetir()
        {
            return _hakkimdaDal.ListeGetir();
        }

        public List<Hakkimda> HakkimdaGetir(int HakkimdaId)
        {
            return _hakkimdaDal.ListeGetir(p => p.HakkimdaId == HakkimdaId);
        }

        public void Sil(int id)
        {
            _hakkimdaDal.Sil(new Hakkimda { HakkimdaId = id });
        }
    }
}
