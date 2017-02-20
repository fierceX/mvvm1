﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leaf.Model
{
    class MyDBContext : DbContext
    {
        public DbSet<GapFilling> GapFillings { get; set; }
        public DbSet<SingleChoice> SingleChoices { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TestPaper> TestPapers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SingleTest>().HasKey(t => new { t.SingleId, t.TestId });
            modelBuilder.Entity<SingleTest>()
                .HasOne(pt => pt.single)
                .WithMany(p => p.testpapers).HasForeignKey(pt => pt.SingleId);
            modelBuilder.Entity<SingleTest>()
                .HasOne(pt => pt.test)
                .WithMany(p => p.singles)
                .HasForeignKey(pt => pt.TestId);

            modelBuilder.Entity<GapTest>().HasKey(t => new { t.GapId, t.TestId });
            modelBuilder.Entity<GapTest>()
                .HasOne(pt => pt.gap)
                .WithMany(p => p.testpapers).HasForeignKey(pt => pt.GapId);
            modelBuilder.Entity<GapTest>()
                .HasOne(pt => pt.test)
                .WithMany(p => p.gapfills)
                .HasForeignKey(pt => pt.TestId);


            base.OnModelCreating(modelBuilder);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Leaf.db");
        }
        

    }
}
