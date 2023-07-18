using Core.Utilities.Results.Abstract;
using Core.Utilities.Security.Jwt;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IUserService
    {
        Task<IResult> RegisterUser(User user);
        Task<IDataResult<AccessToken>> UserLogin(User user);
        Task<IResult> UpdateUser(User user);
        IDataResult<User> Get(Expression<Func<User, bool>> filter);
    }
}
