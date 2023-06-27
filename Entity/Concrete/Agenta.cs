using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Agenta : Unit, IEntity
    {
        public int CenterId { get; set; }
        public TransferCenter TransferCenter { get; set; }
        //public string EntityType { get; set; } = "Agenta"; //gbt
    }
}
