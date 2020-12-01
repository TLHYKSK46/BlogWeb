using BlogBusiness.Abstract;
using BlogDataAccess.Abstract;
using BlogEntities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogBusiness.Concreate
{
  public  class RolYonetici:IRolServis
    {
        private IRolDal _rolDal;

        public RolYonetici(IRolDal rolDal)
        {
            _rolDal = rolDal;
        }

        public void Ekle(Rol rol)
        {
            _rolDal.Ekle(rol);
        }

        public void Guncelle(Rol rol)
        {
            _rolDal.Guncelle(rol);
        }

        public Rol RolGetir(int rolId)
        {
            return _rolDal.Getir(p => p.RolId == rolId || rolId == 0);
        }

        public List<Rol> RolleriGetir()
        {
            return _rolDal.ListeGetir();
        }

        public void Sil(int id)
        {
            _rolDal.Sil(new Rol { RolId = id });
        }
    }
}
