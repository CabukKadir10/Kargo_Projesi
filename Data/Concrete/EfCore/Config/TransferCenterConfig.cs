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
                        UnitId = 1,
                        UnitName = "Name1",
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
                        IsBanned = false,
                        AddressDetail = "Amed merkez"
                    },
                    new TransferCenter
                    {
                        UnitId = 2,
                        UnitName = "Name2",
                        ResponsibleName = "muaz",
                        ResponsibleSurname = "Çabuk",
                        PhoneNumber = "05123456789",
                        Gsm = "085012356",
                        Email = "muaz@gmail.com",
                        Description = "Description",
                        City = "Mardin",
                        District = "Bağlar",
                        NeighBourHood = "mahalle1",
                        Street = "sokak1",
                        IsBanned = false,
                        AddressDetail = "Mardin merkez"
                    },
                    new TransferCenter
                    {
                        UnitId = 3,
                        UnitName = "Name3",
                        ResponsibleName = "yusuf",
                        ResponsibleSurname = "Çabuk",
                        PhoneNumber = "05123456789",
                        Gsm = "085012356",
                        Email = "yusuf@gmail.com",
                        Description = "Description",
                        City = "Konya",
                        District = "Bağlar",
                        NeighBourHood = "mahalle1",
                        Street = "sokak1",
                        IsBanned = false,
                        AddressDetail = "Konya merkez"
                    },
                    new TransferCenter
                    {
                        UnitId = 4,
                        UnitName = "Name4",
                        ResponsibleName = "ahmet",
                        ResponsibleSurname = "Çabuk",
                        PhoneNumber = "05123456789",
                        Gsm = "085012356",
                        Email = "ahmet@gmail.com",
                        Description = "Description",
                        City = "Ankara",
                        District = "Bağlar",
                        NeighBourHood = "mahalle1",
                        Street = "sokak1",
                        IsBanned = false,
                        AddressDetail = "Ankara merkez"
                    },
                    new TransferCenter
                    {
                        UnitId = 5,
                        UnitName = "Name5",
                        ResponsibleName = "mehmet",
                        ResponsibleSurname = "Çabuk",
                        PhoneNumber = "05123456789",
                        Gsm = "085012356",
                        Email = "mehmet@gmail.com",
                        Description = "Description",
                        City = "İstanbul",
                        District = "Bağlar",
                        NeighBourHood = "mahalle1",
                        Street = "sokak1",
                        IsBanned = false,
                        AddressDetail = "İstanbul merkez"
                    }
                );
        }
    }
}
