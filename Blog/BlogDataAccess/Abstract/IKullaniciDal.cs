using BlogCore.Dao.DataAccess;
using BlogEntities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogDataAccess.Abstract
{
    public interface IKullaniciDal : IEntityRepository<Kullanici>
    {
    }
}
