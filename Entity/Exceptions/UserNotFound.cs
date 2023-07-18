using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Exceptions
{
    public sealed class UserNotFound : NotFound
    {
        public UserNotFound(int id) : base($"The user with id : {id} could not found.")
        {
        }
    }
}
