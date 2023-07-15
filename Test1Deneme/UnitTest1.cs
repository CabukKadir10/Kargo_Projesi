using Core.Utilities.Results.Concrete;
using Data.Abstract;
using Entity.Concrete;
using Entity.Concrete.Enum;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Routing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using NUnit.Framework;
using Services.Abstract;
using Services.Concrete;
using System.Linq.Expressions;

namespace Test1Deneme
{
    public class UnitTest1
    {
        private StationManager _stationManager;
        private Mock<IDalManager> _mockDalManager;

        [SetUp]
        public void SetUp()
        {
            _mockDalManager = new Mock<IDalManager>();
            _stationManager = new StationManager(_mockDalManager.Object);
        }

        [Fact]
        public void Add_WhenCountIsLessThanOrEqual10_ShouldCreateStation()
        {
            // Arrange
            var station = new Station
            {
                StationName= "Kadir",
                LineId = 1,
                UnitId = 1
                // Di�er gerekli �zellikleri doldurun
            };

            var line = new Line
            {
                LineId = 1,
                LineType = LineType.outLine
                // Di�er gerekli �zellikleri doldurun
            };

            var existingStations = new List<Station>
            {
                new Station { LineId = 1, UnitId = 2 },
                new Station { LineId = 1, UnitId = 3 }
                // Di�er mevcut istasyonlar� ekleyin
            };

            _mockDalManager.Setup(m => m.LineDal.Get(It.IsAny<Expression<Func<Line, bool>>>())).Returns(line);
            _mockDalManager.Setup(m => m.StationDal.GetList(It.IsAny<Expression<Func<Station, bool>>>())).Returns(existingStations);
            _mockDalManager.Setup(m => m.StationDal.Count(It.IsAny<Expression<Func<Station, bool>>>())).Returns(existingStations.Count);

            // Act
            _stationManager.Add(station);

            // Assert
            _mockDalManager.Verify(m => m.StationDal.Create(It.IsAny<Station>()), Times.Once);
        }
    }
}