using CoursApiEntity.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursApiEntity
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Data Source=(LocalDb)\CoursSql;Integrated Security=True");
        }

        public DbSet<Client> Client { get; set; }
        public DbSet<Adresse> Adresse { get; set; }
    }
}
