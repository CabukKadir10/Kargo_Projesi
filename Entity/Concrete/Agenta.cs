using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Agenta : Unit, IEntity
    {
        public int TransferCenterId { get; set; }
    }
}
