using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Data.Abstract;
using Entity.Concrete;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class RoleManager : IRoleService
    {
        private readonly IDalManager _Dal;

        public RoleManager(IDalManager dal)
        {
            _Dal = dal;
        }

        public IDataResult<Role> GetRole(string name)
        {
            return new SuccessDataResult<Role>(_Dal.RoleDal.Get(a => a.Name == name));
        }
    }
}
