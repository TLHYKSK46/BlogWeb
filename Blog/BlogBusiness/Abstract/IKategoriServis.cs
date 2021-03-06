﻿using BlogEntities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogBusiness.Abstract
{
    public interface IKategoriServis
    {
        List<Kategori> KategorileriGetir();
        Kategori KategoriGetir(int KategoriId);
        void Ekle(Kategori kategori);
        void Guncelle(Kategori kategori);
        void Sil(int id);
    }
}
