using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Exceptions
{
    public sealed class RoleNotFound : NotFound
    {
        public RoleNotFound(int id) : base($"The role with id : {id} could not found.")
        {
        }
    }
}
