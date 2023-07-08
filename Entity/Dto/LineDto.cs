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
        public int Id { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public string CreatorId { get; set; }
        public LineType LineType { get; set; }
        public string LineName { get; set; }
        public IList<StationDto> Station { get; set; }
        public bool IsActive { get; set; }
    }
}
