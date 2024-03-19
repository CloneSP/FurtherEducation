using Microsoft.EntityFrameworkCore;
using NewApp.Entities;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NewApp
{
    internal class MyDbContext : DbContext
    {

        string json = File.ReadAllText("../../Config.json");
        private dynamic dbConfig;
        public MyDbContext()
        {
            dbConfig = JsonConvert.DeserializeObject<dynamic>(this.json);
            ChangeTables();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Curse> Curses { get; set; }
        public DbSet<Class> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>().Property(p => p.Name).HasColumnName("ClassName").IsRequired();
            /*.HasKey() // Сделать Первичным Ключом
             *.HasMany() // Сделать связь один ко многим, многие ко многим и тд
             *.HasOptional() // Сделать ключ который ссылается на первичный ключ или ключ в другой таблице
             *.Ignore() // Не создавать таблицу в БД
             *.ToTable() // Задать имя таблице
             *.HasTableAnnotation() // apply data annotation
             */
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer($"Server={this.dbConfig.Server};Database={this.dbConfig.Database};Trusted_Connection={this.dbConfig.Trusted_Connection};");
        }
        private void ChangeTables()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }

}

