using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Station : IEntity
    {
        public int Id { get; set; }
        public string StationName { get; set; }
        public int OrderNumber { get; set; }
        public bool IsActive { get; set; }
        public int LineId { get; set; }
        public int UnitId { get; set; }
    }
}
