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
    public class TransferCenterConfig : IEntityTypeConfiguration<TransferCenter>
    {
        public void Configure(EntityTypeBuilder<TransferCenter> builder)
        {
            builder.HasData(
                    new TransferCenter
                    {
                        Id = 1,
                        UnitName = "Name1",
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
                        IsDeleted = false,
                        AddressDetail = "Amed merkez"
                    },
                    new TransferCenter
                    {
                        Id = 2,
                        UnitName = "Name2",
                        ManagerName = "muaz",
                        ManagerSurname = "Çabuk",
                        PhoneNumber = "05123456789",
                        Gsm = "085012356",
                        Email = "muaz@gmail.com",
                        Description = "Description",
                        City = "Mardin",
                        District = "Bağlar",
                        NeighBourHood = "mahalle1",
                        Street = "sokak1",
                        IsDeleted = false,
                        AddressDetail = "Mardin merkez"
                    },
                    new TransferCenter
                    {
                        Id = 3,
                        UnitName = "Name3",
                        ManagerName = "yusuf",
                        ManagerSurname = "Çabuk",
                        PhoneNumber = "05123456789",
                        Gsm = "085012356",
                        Email = "yusuf@gmail.com",
                        Description = "Description",
                        City = "Konya",
                        District = "Bağlar",
                        NeighBourHood = "mahalle1",
                        Street = "sokak1",
                        IsDeleted = false,
                        AddressDetail = "Konya merkez"
                    },
                    new TransferCenter
                    {
                        Id = 4,
                        UnitName = "Name4",
                        ManagerName = "ahmet",
                        ManagerSurname = "Çabuk",
                        PhoneNumber = "05123456789",
                        Gsm = "085012356",
                        Email = "ahmet@gmail.com",
                        Description = "Description",
                        City = "Ankara",
                        District = "Bağlar",
                        NeighBourHood = "mahalle1",
                        Street = "sokak1",
                        IsDeleted = false,
                        AddressDetail = "Ankara merkez"
                    },
                    new TransferCenter
                    {
                        Id = 5,
                        UnitName = "Name5",
                        ManagerName = "mehmet",
                        ManagerSurname = "Çabuk",
                        PhoneNumber = "05123456789",
                        Gsm = "085012356",
                        Email = "mehmet@gmail.com",
                        Description = "Description",
                        City = "İstanbul",
                        District = "Bağlar",
                        NeighBourHood = "mahalle1",
                        Street = "sokak1",
                        IsDeleted = false,
                        AddressDetail = "İstanbul merkez"
                    }
                );
        }
    }
}
