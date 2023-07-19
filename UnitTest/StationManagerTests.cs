using Core.Utilities.Results.Concrete;
using Data.Abstract;
using Entity.Concrete.Enum;
using Entity.Concrete;
using Moq;
using Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public class StationManagerTests
    {
        private readonly Mock<IDalManager> _mockDalManager;
        private readonly StationManager _stationManager;

        public StationManagerTests()
        {
            
            _mockDalManager = new Mock<IDalManager>();

            
            _stationManager = new StationManager(_mockDalManager.Object);
        }

        [Fact]
        public void Add_WhenCalledWithValidStation_CreatesStation()
        {
            
            var station = new Station
            {
                Id = 1,
                StationName = "Test Station",
                OrderNumber = 2,
                LineId = 1,
                IsActive = true,
                UnitId = 2
            };

            var line = new Line
            {
                LineId = 1,
                LineName = "Test Line",
                LineType = LineType.outLine
            };

            var listStation = new List<Station>
            {
                new Station { Id = 2, StationName = "Test Station 2", OrderNumber = 3, LineId = 1, IsActive = true, UnitId = 3 }
            };

            var listTransferCenter = new List<TransferCenter>
            {
                new TransferCenter { Id = 2, UnitName = "Test Transfer Center" }
            };

            
            _mockDalManager.Setup(m => m.LineDal.Get(a => a.LineId == station.LineId)).Returns(line).Verifiable();
            _mockDalManager.Setup(m => m.StationDal.GetList(a => a.LineId == station.LineId)).Returns(listStation).Verifiable();
            _mockDalManager.Setup(m => m.StationDal.Count(a => a.LineId == station.LineId)).Returns(2).Verifiable();
            _mockDalManager.Setup(m => m.TransferCenterDal.GetList(null)).Returns(listTransferCenter).Verifiable();
            _mockDalManager.Setup(m => m.StationDal.Create(station)).Verifiable();

            
            _stationManager.Add(station);

           
            _mockDalManager.Verify();
        }

        //[Fact]
        //public void Delete_WhenCalledWithValidStation_ReturnsSuccessResult()
        //{
            
        //    var station = new Station
        //    {
        //        Id = 1,
        //        StationName = "Test Station",
        //        OrderNumber = 2,
        //        LineId = 1,
        //        IsActive = true,
        //        UnitId = 2
        //    };

        //    var expected = new SuccessResult();

           
        //    _mockDalManager.Setup(m => m.StationDal.Delete(station)).Verifiable();

            
        //    var actual = _stationManager.Delete(station);

            
        //    Assert.Equal(expected.Success, actual.Success);
        //    Assert.Equal(expected.Message, actual.Message);
        //    _mockDalManager.Verify();
        //}

        [Fact]
        public void GetByIdStation_WhenCalledWithValidId_ReturnsSuccessDataResult()
        {
            
            var id = 1;

            var station = new Station
            {
                Id = 1,
                StationName = "Test Station",
                OrderNumber = 2,
                LineId = 1,
                IsActive = true,
                UnitId = 2
            };

            var expected = new SuccessDataResult<Station>(station);

            
            _mockDalManager.Setup(m => m.StationDal.Get(u => u.Id == id)).Returns(station).Verifiable();

            var actual = _stationManager.GetByIdStation(id);

           
            Assert.Equal(expected.Success, actual.Success);
            Assert.Equal(expected.Message, actual.Message);
            Assert.Equal(expected.Data, actual.Data);
            _mockDalManager.Verify();
        }

        [Fact]
        public void GetListStation_WhenCalled_ReturnsSuccessDataResult()
        {
            
            var stations = new List<Station>
            {
                new Station { Id = 1, StationName = "Test Station 1", OrderNumber = 2, LineId = 1, IsActive = true, UnitId = 2 },
                new Station { Id = 2, StationName = "Test Station 2", OrderNumber = 3, LineId = 1, IsActive = true, UnitId = 3 },
                new Station { Id = 3, StationName = "Test Station 3", OrderNumber = 2, LineId = 2, IsActive = true, UnitId = 4 },
                new Station { Id = 4, StationName = "Test Station 4", OrderNumber = 3, LineId = 2, IsActive = true, UnitId = 5 }
            };

            var expected = new SuccessDataResult<List<Station>>(stations);

            
            _mockDalManager.Setup(m => m.StationDal.GetList(null)).Returns(stations).Verifiable();

            
            var actual = _stationManager.GetListStation();

           
            Assert.Equal(expected.Success, actual.Success);
            Assert.Equal(expected.Message, actual.Message);
            Assert.Equal(expected.Data, actual.Data);
            _mockDalManager.Verify();
        }
    }
}
