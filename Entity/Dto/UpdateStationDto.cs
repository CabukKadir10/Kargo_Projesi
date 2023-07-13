using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto
{
    public class UpdateStationDto : IDto
    {
        public string StationName { get; set; }
        public int OrderNumber { get; set; }
        public bool IsActive { get; set; }
        public int UnitId { get; set; }
    }
}
