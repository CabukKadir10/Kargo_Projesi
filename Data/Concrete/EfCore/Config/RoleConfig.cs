﻿using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete.EfCore.Config
{
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
                    new Role
                    {
                        Id = 1,
                        Name = "Agenta",
                        NormalizedName = "AGENTA"
                    },
                    new Role
                    {
                        Id = 2,
                        Name = "TransferCenter",
                        NormalizedName = "CENTER"
                    },
                    new Role
                    {
                        Id = 3,
                        Name = "Admin",
                        NormalizedName = "ADMIN"
                    }
                );
        }
    }
}
