using BlogCore.Dao.DataAccess;
using BlogEntities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BlogCore.Dao.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
         where TEntity : class, IEntity, new()
         where TContext : DbContext, new()
    {
        public void Ekle(TEntity entity)
        {
            using (var context = new TContext())
            {
                var date = DateTime.Now;
                var eklenenKayit = context.Entry(entity);
                eklenenKayit.State = EntityState.Added;

                context.SaveChanges();
            }
        }

        public TEntity Getir(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public void Guncelle(TEntity entity)
        {
            using (var context = new TContext())
            {
                var guncellenenKayit = context.Entry(entity);
                guncellenenKayit.State = EntityState.Modified;
                context.SaveChanges();

            }
        }

        public List<TEntity> ListeGetir(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();

            }
        }

        public void Sil(TEntity entity)
        {
            using (var context = new TContext())
            {
                var silinenKayit = context.Entry(entity);
                silinenKayit.State = EntityState.Deleted;
                context.SaveChanges();

            }
        }
    }
}
