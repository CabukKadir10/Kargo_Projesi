using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto
{
    public class UpdateLineDto : IDto
    {
        public int LineId { get; set; }
        public string LineName { get; set; }
        public int LineType { get; set; }
        public bool IsActive { get; set; }
    }
}
