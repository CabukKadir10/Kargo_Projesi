﻿using Core.Data.Concrete;
using Data.Abstract;
using Data.Concrete.EfCore.Context;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete
{
    public class TransferCenterDal : RepositoryBase<TransferCenter, ContextKargo>, ITransferCenterDal
    {
       
    }
}
