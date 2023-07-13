using Entity.Concrete;
using Entity.Dto;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Controllers;

namespace TestProject1
{
    public class test1
    {
        private readonly StationController _station;

        public test1(StationController station)
        {
            _station = station;
        }

        [Fact]
        public void Deneme()
        {
            var result = _station.GetByIdStation(2);

            
            
        }
    }
}
