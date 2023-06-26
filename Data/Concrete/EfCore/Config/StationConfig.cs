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
    public class StationConfig : IEntityTypeConfiguration<Station>
    {
        public void Configure(EntityTypeBuilder<Station> builder)
        {
            builder.HasData(
                    new Station
                    {
                        Id = 1,
                        StationName = "durak1",
                        OrderNumber = 1,
                        LineId = 1,
                        UnitId = 1
                    },
                    new Station
                    {
                        Id = 2,
                        StationName = "durak2",
                        OrderNumber = 2,
                        LineId = 1,
                        UnitId = 2
                    },
                    new Station
                    {
                        Id = 3,
                        StationName = "durak3",
                        OrderNumber = 3,
                        LineId = 1,
                        UnitId = 3
                    },
                    new Station
                    {
                        Id = 4,
                        StationName = "durak4",
                        OrderNumber = 1,
                        LineId = 2,
                        UnitId = 4
                    },
                    new Station
                    {
                        Id = 5,
                        StationName = "durak5",
                        OrderNumber = 2,
                        LineId = 2,
                        UnitId = 5
                    }
                );
        }
    }
}
