using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.Jwt;
using Data.Abstract;
using Entity.Concrete;
using Entity.Exceptions;
using Microsoft.AspNetCore.Identity;
using Services.Abstract;
using Services.Constans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class UserManagerr : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IDalManager _dalManager;
        private readonly ITokenHelper _token;

        public UserManagerr(UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager, IDalManager dalManager, ITokenHelper token)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _dalManager = dalManager;
            _token = token;
        }
        public IDataResult<User> Get(Expression<Func<User, bool>> filter)
        {
            return new SuccessDataResult<User>(_dalManager.UserDal.Get(filter));
        }

        public async Task<IResult> RegisterUser(User user)
        {
           // var getUser = _dalManager.UserDal.Get(a => a.Id == user.Id);
            if(!(_dalManager.UserDal.Any(u => u.PhoneNumber == user.PhoneNumber)))
            {
                var result = await _userManager.CreateAsync(user, user.PasswordHash);
                if (result.Succeeded)
                {
                    var addRole = await _userManager.AddToRoleAsync(user, user.Roles);
                }
            }

            return new SuccessResult(Messages.RegisterUser);
        }

        public async Task<IResult> UpdateUser(User user)
        {
            var getUser = _dalManager.UserDal.Get(a => a.Id == user.Id);
            if (getUser is null)
                throw new UserNotFound(user.Id);

            var updateUser = await _userManager.UpdateAsync(user);
            return new SuccessResult(Messages.UpdatedUser);
        }

        public async Task<IDataResult<AccessToken>> UserLogin(User user)
        {
            var role = _dalManager.RoleDal.Get(a => a.Name == user.Roles);
            var getUser = _dalManager.UserDal.Get(a => a.Id == user.Id);
            if (getUser is null)
                throw new UserNotFound(user.Id);

            var result = await _signInManager.PasswordSignInAsync(user, user.PasswordHash, false, false);
            var token = _token.CreateToken(user, role);
            return new SuccessDataResult<AccessToken>(token);
        }
    }
}
