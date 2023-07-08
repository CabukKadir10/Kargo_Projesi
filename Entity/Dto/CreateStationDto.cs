using Entity.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto
{
    public class CreateStationDto : IDto
    {
        public int Id { get; set; }
        public string StationName { get; set; }
        public int OrderNumber { get; set; }
       // public LineDto Line { get; set; }
        public int LineId { get; set; }
        public int UnitId { get; set; }
    }
}
