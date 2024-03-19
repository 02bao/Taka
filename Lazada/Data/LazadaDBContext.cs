﻿using Lazada.Models;
using Microsoft.EntityFrameworkCore;

namespace Lazada.Data
{
    public class LazadaDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public static string configsql = "Host=localhost:5432;Database=Lazada;Username=postgres;Password=postgres";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(configsql);
        }
    }
}