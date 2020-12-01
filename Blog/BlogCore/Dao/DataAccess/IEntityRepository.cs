using BlogEntities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BlogCore.Dao.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T Getir(Expression<Func<T, bool>> filter = null);
        List<T> ListeGetir(Expression<Func<T, bool>> filter = null);
        void Ekle(T entity);
        void Guncelle(T entity);
        void Sil(T entity);

    }
}
