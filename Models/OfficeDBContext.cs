using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SysTech
{
    public class OfficeContext : DbContext
    {
        private string connectionString;
        public OfficeContext (string connectionString) 
        {
            this.connectionString = connectionString; //Раз мы каждый раз в контроллер передаём строку подключения, то и в контрукторе тоже пусть будет
        }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Worker> Workers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionString);
        }
    }

    public class DBOptions
    {
        public string ConnString { get; set; }
    }
}