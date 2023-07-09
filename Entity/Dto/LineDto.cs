using Entity.Concrete;
using Entity.Concrete.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto
{
    public class LineDto
    {
        public int LineId { get; set; }
        public string LineName { get; set; }
        public LineType LineType { get; set; }
        public bool IsActive { get; set; }
        public IList<StationDto> Station { get; set; }
    }
}
