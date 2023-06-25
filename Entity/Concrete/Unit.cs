using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Unit : IEntity
    {
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public string ResponsibleName { get; set; }
        public string ResponsibleSurname { get; set; }
        public string PhoneNumber { get; set; }
        public string Gsm { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public Address Address { get; set; }
    }
}
