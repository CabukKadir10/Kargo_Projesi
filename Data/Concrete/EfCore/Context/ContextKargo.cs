using Data.Concrete.EfCore.Config;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete.EfCore.Context
{
    public class ContextKargo  : IdentityDbContext<User, Role, int>
    {
        public ContextKargo(DbContextOptions<ContextKargo> options)
        : base(options)
        {
            // Yapıcı metot içeriği
        }
        public ContextKargo()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=DbKargo;UserName=postgres;Password=1234");

            //AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=DbKargo;UserName=postgres;Password=1234");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new StationConfig());
            modelBuilder.ApplyConfiguration(new LineConfig());
            modelBuilder.ApplyConfiguration(new TransferCenterConfig());
            modelBuilder.ApplyConfiguration(new AgentaConfig());
            modelBuilder.ApplyConfiguration(new RoleConfig());
            // test 


            //modelBuilder.Entity<Agenta>().HasKey(d => d.Id);
            //modelBuilder.Entity<TransferCenter>().HasKey(d => d.Id);

            modelBuilder.Entity<Agenta>()
                .HasOne(d => d.TransferCenter)
                .WithMany(d => d.Agentas)
                .HasForeignKey(d => d.CenterId);
            //modelBuilder.Entity<Agenta>()
            //    .HasDiscriminator<string>("EntityType")
            //    .HasValue<Agenta>("Agenta")
            //    .HasValue<TransferCenter>("TransferCenter");

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
        public DbSet<Unit> Units { get; set; }
        public DbSet<Line> Lines { get; set; }
        public DbSet<Agenta> Agentas { get; set; }
        public DbSet<TransferCenter> TransferCenters { get; set; }
    }
}
