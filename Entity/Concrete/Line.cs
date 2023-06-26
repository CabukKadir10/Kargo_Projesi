using Entity.Abstract;
using Entity.Concrete.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Line : IEntity
    {
        public int LineId { get; set; }
        public string LineName { get; set; }
        public LineType LineType { get; set; }
        public bool IsActive { get; set; }
        public IList<Station> Stations { get; set; }
    }
}
