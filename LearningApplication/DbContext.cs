using LearningApplication.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace LearningApplication
{
    class DatabaseContext : DbContext
    {
        public DbSet<CardStacks> CardStacks { get; set; }
        public DbSet<Words> Words { get; set; }
        public DbSet<SessionStatistics> SessionStatistics { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-664C7U11\\SQLEXPRESS;Initial Catalog=LEARNING;Integrated Security=True; TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CardStacks>(cs =>
            {
                cs.HasMany(c => c.Words)
                .WithOne(w => w.CardStack)
                .HasForeignKey(w => w.CardStackId);

                cs.HasMany(c => c.SessionStatistics)
                .WithOne(s => s.CardStack)
                .HasForeignKey(s => s.CardStackId);
            });
        }
    }
}
