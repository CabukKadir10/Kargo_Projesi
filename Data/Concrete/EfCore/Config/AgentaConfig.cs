using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete.EfCore.Config
{
    public class AgentaConfig : IEntityTypeConfiguration<Agenta>
    {
        public void Configure(EntityTypeBuilder<Agenta> builder)
        {
            builder.HasData(
                new Agenta
                {
                    UnitId = 6,
                    UnitName = "agenta1",
                    ResponsibleName = "kadir",
                    ResponsibleSurname = "Çabuk",
                    PhoneNumber = "05123456789",
                    Gsm = "085012356",
                    Email = "kadir@gmail.com",
                    Description = "Description",
                    City = "Diyarbakır",
                    District = "Bağlar",
                    NeighBourHood = "mahalle1",
                    Street = "sokak1",
                    AddressDetail = "Amed merkez",
                    CenterId = 1
                },
                new Agenta
                {
                    UnitId = 7,
                    UnitName = "agenta2",
                    ResponsibleName = "kadir",
                    ResponsibleSurname = "Çabuk",
                    PhoneNumber = "05123456789",
                    Gsm = "085012356",
                    Email = "kadir@gmail.com",
                    Description = "Description",
                    City = "Diyarbakır",
                    District = "Bağlar",
                    NeighBourHood = "mahalle1",
                    Street = "sokak1",
                    AddressDetail = "Amed merkez",
                    CenterId = 2
                },
                new Agenta
                {
                    UnitId = 8,
                    UnitName = "agenta3",
                    ResponsibleName = "kadir",
                    ResponsibleSurname = "Çabuk",
                    PhoneNumber = "05123456789",
                    Gsm = "085012356",
                    Email = "kadir@gmail.com",
                    Description = "Description",
                    City = "Diyarbakır",
                    District = "Bağlar",
                    NeighBourHood = "mahalle1",
                    Street = "sokak1",
                    AddressDetail = "Amed merkez",
                    CenterId = 2
                },
                new Agenta
                {
                    UnitId = 9,
                    UnitName = "agenta4",
                    ResponsibleName = "kadir",
                    ResponsibleSurname = "Çabuk",
                    PhoneNumber = "05123456789",
                    Gsm = "085012356",
                    Email = "kadir@gmail.com",
                    Description = "Description",
                    City = "Diyarbakır",
                    District = "Bağlar",
                    NeighBourHood = "mahalle1",
                    Street = "sokak1",
                    AddressDetail = "Amed merkez",
                    CenterId = 1
                },
                new Agenta
                {
                    UnitId = 10,
                    UnitName = "agenta5",
                    ResponsibleName = "kadir",
                    ResponsibleSurname = "Çabuk",
                    PhoneNumber = "05123456789",
                    Gsm = "085012356",
                    Email = "kadir@gmail.com",
                    Description = "Description",
                    City = "Diyarbakır",
                    District = "Bağlar",
                    NeighBourHood = "mahalle1",
                    Street = "sokak1",
                    AddressDetail = "Amed merkez",
                    CenterId = 1
                }
            );
        }
    }
}
