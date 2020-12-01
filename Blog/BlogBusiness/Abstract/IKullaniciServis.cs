using BlogEntities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogBusiness.Abstract
{
   public interface IKullaniciServis
    {
        List<Kullanici> KullanicilariGetir();
        List<Kullanici> RoleGoreGetir(int rolId);
        Kullanici KullaniciGetir(int Id);
        void Ekle(Kullanici kullanici);
        void Guncelle(Kullanici kullanici);
        void Sil(int id);
    }
}
