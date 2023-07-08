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
    public class LineConfig : IEntityTypeConfiguration<Line>
    {
        public void Configure(EntityTypeBuilder<Line> builder)
        {
            builder.HasData(
                    new Line
                    {
                        LineId = 1,
                        LineName = "Diyarbakır Hattı",
                        LineType = Entity.Concrete.Enum.LineType.outLine,
                        IsActive = true
                    },
                    new Line
                    {
                        LineId = 2,
                        LineName = "Mardin Hattı",
                        LineType = Entity.Concrete.Enum.LineType.outLine,
                        IsActive = true
                    },
                    new Line
                    {
                        LineId = 3,
                        LineName = "Mersin Hattı",
                        LineType = Entity.Concrete.Enum.LineType.outLine,
                        IsActive = true
                    },
                    new Line
                    {
                        LineId = 4,
                        LineName = "Ankara Hattı",
                        LineType = Entity.Concrete.Enum.LineType.outLine,
                        IsActive = true
                    },
                    new Line
                    {
                        LineId = 5,
                        LineName = "İstanbul Hattı",
                        LineType = Entity.Concrete.Enum.LineType.intermediateLine,
                        IsActive = true
                    }
                );
        }
    }
}
