using System;
using System.Collections.Generic;
using System.Text;

namespace BlogBusiness.Abstract
{
    public class IKategoriServis
    {
        List<Kategori> KategorileriGetir();
        List<Kategori> KategoriGetir(int KategoriId);
        void Ekle(Kategori kategori);
        void Guncelle(Kategori kategori);
        void Sil(int id);
    }
}
