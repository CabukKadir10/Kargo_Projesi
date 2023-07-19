using Entity.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto
{
    public class CreateLineDto : IDto
    {
        public string LineName { get; set; }
        public int LineType { get; set; }
        public int CenterId { get; set; }
       // public CreateStationDto[] Stations { get; set; }
        public int[] Station { get; set; }
        public bool IsActive { get; set; }
    }
}
