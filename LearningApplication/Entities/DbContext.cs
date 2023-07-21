using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace LearningApplication.Entities
{
    class DatabaseContext : DbContext
    {
        public DbSet<CardStack> CardStack { get; set; }
        public DbSet<Word> Word { get; set; }
        public DbSet<SessionStatistic> SessionStatistic { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-664C7U11\\SQLEXPRESS;Initial Catalog=LEARNING;Integrated Security=True; TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CardStack>(cs =>
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
