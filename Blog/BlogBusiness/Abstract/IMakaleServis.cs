using BlogEntities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogBusiness.Abstract
{
   public interface IMakaleServis
    {
        List<Makale> MakaleleriGetir();
        List<Makale> MakaleGetir(int MakaleId);
        List<Makale> KategoriyeGoreGetir(int KategoriId);
        void Ekle(Makale makale);
        void Guncelle(Makale makale);
        void Sil(int id);
    }
}
