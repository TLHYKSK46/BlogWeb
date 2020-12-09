using BlogEntities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogBusiness.Abstract
{
    public interface IBildirimServis
    {
        List<Bildirim> BildirimleriGetir();
        Bildirim BildirimGetir(int Id);
        void Ekle(Bildirim bildirim);
        void Guncelle(Bildirim bildirim);
        void Sil(int id);
    }
}
