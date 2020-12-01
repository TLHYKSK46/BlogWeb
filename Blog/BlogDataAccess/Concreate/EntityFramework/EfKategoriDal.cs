using BlogCore.Dao.EntityFramework;
using BlogDataAccess.Abstract;
using BlogEntities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogDataAccess.Concreate.EntityFramework
{
    public class EfKategoriDal : EfEntityRepositoryBase<Kategori, BlogContext>, IKategoriDal
    {
    }
}
