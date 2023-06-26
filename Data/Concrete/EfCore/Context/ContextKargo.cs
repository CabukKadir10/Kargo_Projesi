﻿using Data.Concrete.EfCore.Config;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete.EfCore.Context
{
    public class ContextKargo : DbContext
    {
        //public ContextKargo(DbContextOptions<ContextKargo> options)
        //: base(options)
        //{
        //    // Yapıcı metot içeriği
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432; Database=DbKargo; UserName=postgres ; Password=1234");
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new StationConfig());
            modelBuilder.ApplyConfiguration(new AgentaConfig());
            modelBuilder.ApplyConfiguration(new LineConfig());
            modelBuilder.ApplyConfiguration(new TransferCenterConfig());

            modelBuilder.Entity<Agenta>().HasKey(d => d.UnitId);
            modelBuilder.Entity<TransferCenter>().HasKey(d => d.UnitId);

            modelBuilder.Entity<Agenta>()
                .HasOne(d => d.TransferCenter)
                .WithMany(d => d.Agentas)
                .HasForeignKey(d => d.CenterId);

            modelBuilder.Entity<Station>()
                .HasOne(d => d.Line)
                .WithMany(d => d.Stations)
                .HasForeignKey(d => d.LineId);

            //modelBuilder.Entity<Station>()
            //    .HasMany(d => d.Units)
            //    .WithMany(d => d.Stations)
            //    .UsingEntity(j => j.ToTable("UnitsStations"));

            //modelBuilder.Entity<Agenta>()
            //     .HasOne(k => k.TransferCenter)
            //     .WithMany(d => d.Agentas)
            //     .HasForeignKey(c => c.TmId);

            //modelBuilder.Entity<Agenta>()
            //    .HasOne(z => z.Address)
            //    .WithOne(d => d.Agenta)
            //    .HasForeignKey<Address>(c => c.ForId);
                
        }

        public DbSet<Agenta> Agentas { get; set; }
        public DbSet<Line> Lines { get; set; }
        public DbSet<TransferCenter> TransferCenters { get; set; }
       // public DbSet<Unit> Units { get; set; }
    }
}
