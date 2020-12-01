using BlogEntities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogBusiness.Abstract
{
   public interface IYorumServis
    {
        List<Yorum> YorumlariGetir();
        List<Yorum> YorumGetir(int YorumId);
        void Ekle(Yorum Yorum);
        void Guncelle(Yorum Yorum);
        void Sil(int id);
    }
}
