using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Exceptions
{
    public class LineNotFound : NotFound
    {
        public LineNotFound(int id) : base($"The book with id : {id} could not found.")
        {
        }
    }
}
