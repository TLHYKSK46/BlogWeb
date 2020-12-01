using BlogEntities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogBusiness.Abstract
{
   public interface IHakkimdaServis
    {
        List<Hakkimda> HakkimdaGetir();
        List<Hakkimda> HakkimdaGetir(int HakkimdaId);
        void Ekle(Hakkimda Hakkimda);
        void Guncelle(Hakkimda Hakkimda);
        void Sil(int id);
    }
}
