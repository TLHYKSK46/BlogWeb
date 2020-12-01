using BlogEntities.Concreate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogDataAccess.Concreate.EntityFramework
{
    public class BlogContext : DbContext
    {
        public BlogContext() { }

        public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //  
        {
            // optionsBuilder.UseNpgsql(@"Server=localhost;User ID=postgres;Password=8254;Port=5433;Database=BlogDb;Integrated Security=true;Pooling=true;");
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=BlogDb;Trusted_Connection=True;MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);

        }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Rol> Roller { get; set; }
        public DbSet<Makale> Makaleler { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Yorum> Yorumlar { get; set; }
        public DbSet<Hakkimda> Hakkimda { get; set; }
        public DbSet<Referans> Referanslar { get; set; }
        public DbSet<Iletisim> Iletisim { get; set; }




    }
}
