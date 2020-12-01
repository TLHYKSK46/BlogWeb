using BlogBusiness.Abstract;
using BlogDataAccess.Abstract;
using BlogEntities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogBusiness.Concreate
{
  public  class IletisimYonetici:IIletisimServis
    {
        IIletisimDal _iletisimDal;
        public IletisimYonetici(IIletisimDal iletisimDal)
        {
            _iletisimDal = iletisimDal;
        }

        public void Ekle(Iletisim iletisim)
        {
            _iletisimDal.Ekle(iletisim);
        }

        public void Guncelle(Iletisim iletisim)
        {
            _iletisimDal.Guncelle(iletisim);
        }

        public List<Iletisim> IletisimBilgileriniGetir()
        {
            return _iletisimDal.ListeGetir();
        }

        public List<Iletisim> IletisimGetir(int IletisimId)
        {
            return _iletisimDal.ListeGetir(p => p.IletisimId == IletisimId);
        }

        public void Sil(int id)
        {
            _iletisimDal.Sil(new Iletisim { IletisimId = id });
        }

    }
}
