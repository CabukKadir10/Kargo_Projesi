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
                    Id = 6,
                    UnitName = "agenta1",
                    ManagerName = "kadir",
                    ManagerSurname = "Çabuk",
                    PhoneNumber = "05123456789",
                    Gsm = "085012356",
                    Email = "kadir@gmail.com",
                    Description = "Description",
                    City = "Diyarbakır",
                    District = "Bağlar",
                    NeighBourHood = "mahalle1",
                    Street = "sokak1",
                    AddressDetail = "Amed merkez",
                    IsDeleted = false,
                    CenterId = 1
                },
                new Agenta
                {
                    Id = 7,
                    UnitName = "agenta2",
                    ManagerName = "kadir",
                    ManagerSurname = "Çabuk",
                    PhoneNumber = "05123456789",
                    Gsm = "085012356",
                    Email = "kadir@gmail.com",
                    Description = "Description",
                    City = "Diyarbakır",
                    District = "Bağlar",
                    NeighBourHood = "mahalle1",
                    Street = "sokak1",
                    AddressDetail = "Amed merkez",
                    IsDeleted = false,
                    CenterId = 1
                },
                new Agenta
                {
                    Id = 8,
                    UnitName = "agenta3",
                    ManagerName = "kadir",
                    ManagerSurname = "Çabuk",
                    PhoneNumber = "05123456789",
                    Gsm = "085012356",
                    Email = "kadir@gmail.com",
                    Description = "Description",
                    City = "Diyarbakır",
                    District = "Bağlar",
                    NeighBourHood = "mahalle1",
                    Street = "sokak1",
                    AddressDetail = "Amed merkez",
                    IsDeleted = false,
                    CenterId = 1
                },
                new Agenta
                {
                    Id = 9,
                    UnitName = "agenta4",
                    ManagerName = "kadir",
                    ManagerSurname = "Çabuk",
                    PhoneNumber = "05123456789",
                    Gsm = "085012356",
                    Email = "kadir@gmail.com",
                    Description = "Description",
                    City = "Diyarbakır",
                    District = "Bağlar",
                    NeighBourHood = "mahalle1",
                    Street = "sokak1",
                    AddressDetail = "Amed merkez",
                    IsDeleted = false,
                    CenterId = 1
                },
                new Agenta
                {
                    Id = 10,
                    UnitName = "agenta5",
                    ManagerName = "kadir",
                    ManagerSurname = "Çabuk",
                    PhoneNumber = "05123456789",
                    Gsm = "085012356",
                    Email = "kadir@gmail.com",
                    Description = "Description",
                    City = "Diyarbakır",
                    District = "Bağlar",
                    NeighBourHood = "mahalle1",
                    Street = "sokak1",
                    AddressDetail = "Amed merkez",
                    IsDeleted = false,
                    CenterId = 1
                }
            );
        }
    }
}
