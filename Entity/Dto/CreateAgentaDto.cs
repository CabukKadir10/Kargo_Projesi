﻿using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto
{
    public class CreateAgentaDto : IDto
    {
       // public int UnitId { get; set; }
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
        public int CenterId { get; set; }
    }
}
