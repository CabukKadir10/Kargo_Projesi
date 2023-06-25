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

        public DbSet<Agenta> Agentas { get; set; }
        public DbSet<Line> Lines { get; set; }
        public DbSet<TransferCenter> TransferCenters { get; set; }
        public DbSet<Unit> Units { get; set; }
    }
}
