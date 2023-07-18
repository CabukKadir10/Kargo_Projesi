using Core.Data.Concrete;
using Data.Abstract;
using Data.Concrete.EfCore.Context;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete
{
    public class UserDal : RepositoryBase<User, ContextKargo>, IUserDal
    {
    }
}
