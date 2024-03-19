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

            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer($"Server={this.dbConfig.Server};Database={this.dbConfig.Database};Trusted_Connection={this.dbConfig.Trusted_Connection};");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Curse> Curses { get; set; }
        public DbSet<Department> Departments { get; set; }
    }

}

