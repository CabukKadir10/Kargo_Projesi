using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IRoleService
    {
        IDataResult<Role> GetRole(string name);
    }
}
