using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Unit : IEntity
    {
        public int Id { get; set; }
        public string UnitName { get; set; }
        public string ManagerName { get; set; }
        public string ManagerSurname { get; set; }
        public string PhoneNumber { get; set; }
        public string Gsm { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string NeighBourHood { get; set; }
        public string Street { get; set; }
        public string AddressDetail { get; set; }
        public bool IsDeleted { get; set; }
        [ConcurrencyCheck]
        public virtual string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();
        //public int StationsId { get; set; }
        //public IList<Station> Stations { get; set; }
        //public IList<Line> Lines { get; set; }
    }
}
