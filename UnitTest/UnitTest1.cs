using Entity.Concrete;
using Moq;
using Services.Abstract;

namespace UnitTest
{
    public class UnitTest1
    {
        //private readonly IStationService _stationService;

        //public UnitTest1(IStationService stationService)
        //{
        //    _stationService = stationService;
        //}

        [Fact]
        public void Should_Get_By_Id_Agenta()
        {
            var agenta = new Agenta();
            var service = new Mock<IAgentaService>();
            
            service.Setup(m => m.Get(6)).Returns(agenta);
            var result = service.Object.Get(6);

            Assert.Equal(agenta, result);
            
        }

        [Fact]
        public void Should_Returns_GetListAgenta()
        {

        }
    }
}