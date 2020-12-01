using BlogBusiness.Abstract;
using BlogDataAccess.Abstract;
using BlogEntities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogBusiness.Concreate
{
   public class KullaniciYonetici:IKullaniciServis
    {

        private IKullaniciDal _kullaniciDal;

        public KullaniciYonetici(IKullaniciDal kullaniciDal)
        {
            _kullaniciDal = kullaniciDal;
        }

        public void Ekle(Kullanici kullanici)
        {
            _kullaniciDal.Ekle(kullanici);
        }

        public void Guncelle(Kullanici kullanici)
        {
            _kullaniciDal.Guncelle(kullanici);

        }

        public Kullanici KullaniciGetir(int Id)
        {
            return _kullaniciDal.Getir(x => x.KullaniciId == Id);
        }

        public List<Kullanici> KullanicilariGetir()
        {
            return _kullaniciDal.ListeGetir();
        }

        public List<Kullanici> RoleGoreGetir(int rolId)
        {
            return _kullaniciDal.ListeGetir(p => p.RolId == rolId);
        }

        public void Sil(int id)
        {
            _kullaniciDal.Sil(new Kullanici { KullaniciId = id });

        }

    }
}
