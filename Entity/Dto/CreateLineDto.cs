using Entity.Abstract;
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
    }
}
