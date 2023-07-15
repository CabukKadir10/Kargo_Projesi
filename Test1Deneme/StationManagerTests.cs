using Data.Abstract;
using Entity.Concrete;
using Moq;
using NUnit.Framework;
using Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Assert = NUnit.Framework.Assert;

namespace Test1Deneme
{
    [TestFixture]
    public class StationManagerTests
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
        public void GetListStation_ShouldReturnListOfStations()
        {
            // Arrange
            var expectedStations = new List<Station>
            {
                new Station { Id = 1, StationName = "Station 1", OrderNumber = 1, IsActive = true, LineId = 0, UnitId = 2 },
                new Station { Id = 2, StationName = "Station 2", OrderNumber = 2, IsActive = true, LineId = 3, UnitId = 4},
                // Diğer istasyonları ekleyin
            };

            Expression<Func<Station, bool>> filter = null;
            _mockDalManager.Setup(m => m.StationDal.GetList(It.IsAny<Expression<Func<Station, bool>>>())).Returns(expectedStations);

            // Act
            var result = _stationManager.GetListStation2(filter);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Success);
            Assert.AreEqual(expectedStations, result.Data);
        }

        // Diğer test senaryolarını buraya ekleyebilirsiniz

    }
}
