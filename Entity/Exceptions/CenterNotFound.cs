using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Exceptions
{
    public class CenterNotFound : NotFound
    {
        public CenterNotFound(int id) : base($"The book with id : {id} could not found.")
        {
        }
    }
}
