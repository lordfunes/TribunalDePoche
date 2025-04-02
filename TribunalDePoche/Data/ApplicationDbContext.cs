using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Xml.Linq;
using TribunalDePoche.Models;

namespace TribunalDePoche.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Celebrity> Celebrities { get; set; }
        public DbSet<Trial> Trials { get; set; }
        public DbSet<Prediction> Predictions { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
        .Property(u => u.Email)
        .HasMaxLength(255);
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();

            modelBuilder.Entity<Prediction>()
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Prediction>()
                .HasOne(p => p.Trial)
                .WithMany()
                .HasForeignKey(p => p.TrialId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Trial)
                .WithMany()
                .HasForeignKey(c => c.TrialId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}