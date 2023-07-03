using Core.Utilities.Results.Abstract;
using Core.Utilities.Security.Jwt;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IAuthService
    {
        IDataResult<AccessToken> CreateAccessToken(User user, Role role);
    }
}
