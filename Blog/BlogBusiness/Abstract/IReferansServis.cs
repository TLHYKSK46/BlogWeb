using BlogEntities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogBusiness.Abstract
{
  public  interface IReferansServis
    {
        List<Referans> ReferanslariGetir();
        List<Referans> ReferansGetir(int projeId);
        void Ekle(Referans referans);
        void Guncelle(Referans referans);
        void Sil(int id);
    }
}
