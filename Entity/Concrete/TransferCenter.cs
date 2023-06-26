using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class TransferCenter : Unit, IEntity
    {
        public IList<Agenta> Agentas { get; set; }
    }
}
