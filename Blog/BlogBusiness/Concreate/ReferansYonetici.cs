using BlogBusiness.Abstract;
using BlogDataAccess.Abstract;
using BlogEntities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogBusiness.Concreate
{
    public class ReferansYonetici:IReferansServis
    {

        private IReferansDal _referansDal;
        public ReferansYonetici(IReferansDal referansDal)
        {
            _referansDal = referansDal;
        }

        public void Ekle(Referans referans)
        {
            _referansDal.Ekle(referans);
        }

        public void Guncelle(Referans referans)
        {
            _referansDal.Guncelle(referans);
        }

        public List<Referans> ReferansGetir(int projeId)
        {
            return _referansDal.ListeGetir(p => p.ProjeId == projeId || projeId == 0);
        }

        public List<Referans> ReferanslariGetir()
        {
            return _referansDal.ListeGetir();
        }

        public void Sil(int id)
        {
            _referansDal.Sil(new Referans { ProjeId = id });
        }
    }
}
