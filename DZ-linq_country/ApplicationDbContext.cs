using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_linq_country
{
    class ApplicationDbContext : DbContext
    {
        public DbSet<Models.Category> Categories { get; set; }
        public DbSet<Models.Country> Сountries { get; set; }
        public DbSet<Models.Area> Areas { get; set; }
        public DbSet<Models.City> Cities { get; set; }

        private string sqlConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\karas\source\repos\DZ-linq_country\DZ-linq_country\Database1.mdf;Integrated Security=True";

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Models.Category>()
               .HasOne<Models.Category>(c => c.ParentCategory);

            builder.Entity<Models.Category>()
                .HasMany<Models.Category>(c => c.ChildCategories);

            builder.Entity<Models.Category>()
                .HasMany<Models.Category>(c => c.ChildCategories);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(sqlConnectionString);
        }
    }
}
