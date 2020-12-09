using BlogBusiness.Abstract;
using BlogDataAccess.Abstract;
using BlogEntities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogBusiness.Concreate
{
    public class BildirimYonetici : IBildirimServis
    {
        private IBildirimDal _bildirimDal;

        public BildirimYonetici(IBildirimDal bildirimDal)
        {
            _bildirimDal = bildirimDal;
        }

        public Bildirim BildirimGetir(int Id)
        {
            return _bildirimDal.Getir(x=>x.id==Id);
        }

        public List<Bildirim> BildirimleriGetir()
        {
            return _bildirimDal.ListeGetir();
        }

        public void Ekle(Bildirim bildirim)
        {
            _bildirimDal.Ekle(bildirim);
        }

        public void Guncelle(Bildirim bildirim)
        {
            _bildirimDal.Guncelle(bildirim);
        }

        public void Sil(int id)
        {
            _bildirimDal.Sil(new Bildirim { id=id});
        }
    }
}
