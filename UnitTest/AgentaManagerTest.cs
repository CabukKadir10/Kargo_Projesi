using Data.Abstract;
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
    public class AgentaManagerTest
    {
        private Mock<IDalManager> _mockDalManager;
        private Mock<IAgentaDal> _mockAgentaDal;
        private AgentaManager _agentaManager;
        private List<Agenta> _testAgentas;

        public AgentaManagerTest()
        {
            
            _mockDalManager = new Mock<IDalManager>();
            _mockAgentaDal = new Mock<IAgentaDal>();
            _agentaManager = new AgentaManager(_mockDalManager.Object);
            _testAgentas = new List<Agenta>
            {
                new Agenta
                {
                    Id = 1,
                    UnitName = "agenta1",
                    ManagerName = "kadir",
                    ManagerSurname = "Çabuk",
                    PhoneNumber = "05148456789",
                    Gsm = "087012356",
                    Email = "kadirrr@gmail.com",
                    Description = "Description",
                    City = "Diyarbakır",
                    District = "Bağlar",
                    NeighBourHood = "mahalle1",
                    Street = "sokak1",
                    AddressDetail = "Amed merkez",
                    IsDeleted = false,
                    CenterId = 1
                },
                new Agenta
                {
                    Id = 2,
                    UnitName = "agenta2",
                    ManagerName = "kadir",
                    ManagerSurname = "Çabuk",
                    PhoneNumber = "05123456789",
                    Gsm = "085012356",
                    Email = "kadir@gmail.com",
                    Description = "Description",
                    City = "Diyarbakır",
                    District = "Bağlar",
                    NeighBourHood = "mahalle1",
                    Street = "sokak1",
                    AddressDetail = "Amed merkez",
                    IsDeleted = false,
                    CenterId = 1
                },
                new Agenta
                {
                    Id = 3,
                    UnitName = "agenta3",
                    ManagerName = "kadir",
                    ManagerSurname = "Çabuk",
                    PhoneNumber = "05123456789",
                    Gsm = "085012356",
                    Email = "kadir@gmail.com",
                    Description = "Description",
                    City = "Diyarbakır",
                    District = "Bağlar",
                    NeighBourHood = "mahalle1",
                    Street = "sokak1",
                    AddressDetail = "Amed merkez",
                    IsDeleted = false,
                    CenterId = 1
                },
                new Agenta
                {
                    Id = 4,
                    UnitName = "agenta4",
                    ManagerName = "kadir",
                    ManagerSurname = "Çabuk",
                    PhoneNumber = "05123456789",
                    Gsm = "085012356",
                    Email = "kadir@gmail.com",
                    Description = "Description",
                    City = "Diyarbakır",
                    District = "Bağlar",
                    NeighBourHood = "mahalle1",
                    Street = "sokak1",
                    AddressDetail = "Amed merkez",
                    IsDeleted = false,
                    CenterId = 1
                },
                new Agenta
                {
                    Id = 5,
                    UnitName = "agenta5",
                    ManagerName = "kadir",
                    ManagerSurname = "Çabuk",
                    PhoneNumber = "05123456789",
                    Gsm = "085012356",
                    Email = "kadir@gmail.com",
                    Description = "Description",
                    City = "Diyarbakır",
                    District = "Bağlar",
                    NeighBourHood = "mahalle1",
                    Street = "sokak1",
                    AddressDetail = "Amed merkez",
                    IsDeleted = false,
                    CenterId = 1
                }
            };
            _mockDalManager.Setup(m => m.AgentaDal).Returns(_mockAgentaDal.Object);
        }

        [Fact]
        public void Add_ShouldCallCreateMethodOfAgentaDal_WhenAgentaIsValidAndCenterHasLessThan10Agentas()
        {
            
            var newAgenta = new Agenta
            {
                Id = 6,
                UnitName = "agenta1",
                ManagerName = "kadir",
                ManagerSurname = "Çabuk",
                PhoneNumber = "05123456789",
                Gsm = "085012356",
                Email = "kadir@gmail.com",
                Description = "Description",
                City = "Diyarbakır",
                District = "Bağlar",
                NeighBourHood = "mahalle1",
                Street = "sokak1",
                AddressDetail = "Amed merkez",
                IsDeleted = false,
                CenterId = 1
            };

            
            _agentaManager.Add(newAgenta);

            
            _mockAgentaDal.Verify(m => m.Create(newAgenta), Times.Once);
        }

        [Fact]
        public void Add_ShouldNotCallCreateMethodOfAgentaDal_WhenAgentaIsValidAndCenterHasMoreThan10Agentas()
        {
           
            var newAgenta = new Agenta
            {
                Id = 6,
                UnitName = "agenta1",
                ManagerName = "kadir",
                ManagerSurname = "Çabuk",
                PhoneNumber = "05123456789",
                Gsm = "085012356",
                Email = "kadir@gmail.com",
                Description = "Description",
                City = "Diyarbakır",
                District = "Bağlar",
                NeighBourHood = "mahalle1",
                Street = "sokak1",
                AddressDetail = "Amed merkez",
                IsDeleted = false,
                CenterId = 1
            };

            _mockAgentaDal.Setup(m => m.Count(a => a.CenterId == newAgenta.CenterId)).Returns(10);

            
            _agentaManager.Add(newAgenta);

            
            _mockAgentaDal.Verify(m => m.Create(newAgenta), Times.Never);
        }

        //[Fact]
        //public void Delete_ShouldCallDeleteMethodOfAgentaDal_WhenAgentaExists()
        //{
        //    var existingAgenta = _testAgentas[0];
        //    _mockAgentaDal.Setup(m => m.Get(u => u.Id == existingAgenta.Id)).Returns(existingAgenta);

            
        //    _agentaManager.Delete(existingAgenta);

            
        //    _mockAgentaDal.Verify(m => m.Delete(existingAgenta), Times.Once);
        //}

        //[Fact]//**  bunada bak
        //public void Delete_ShouldNotCallDeleteMethodOfAgentaDal_WhenAgentaDoesNotExist()
        //{
            
        //    var nonExistingAgenta = new Agenta
        //    {
        //        Id = 6,
        //        UnitName = "agenta1",
        //        ManagerName = "kadir",
        //        ManagerSurname = "Çabuk",
        //        PhoneNumber = "05123456789",
        //        Gsm = "085012356",
        //        Email = "kadir@gmail.com",
        //        Description = "Description",
        //        City = "Diyarbakır",
        //        District = "Bağlar",
        //        NeighBourHood = "mahalle1",
        //        Street = "sokak1",
        //        AddressDetail = "Amed merkez",
        //        IsDeleted = false,
        //        CenterId = 1
        //    };
        //    _mockAgentaDal.Setup(m => m.Get(u => u.Id == nonExistingAgenta.Id)).Returns((Agenta)null);

           
        //    _agentaManager.Delete(nonExistingAgenta);

            
        //    _mockAgentaDal.Verify(m => m.Delete(nonExistingAgenta), Times.Never);
        //}

        [Fact]//** buna bak
        public void Get_ShouldReturnTheCorrectAgenta_WhenIdIsGiven()
        {
            //ressDetail = "Amed merkez", CenterId = 1, City = "Diyarbakır", ConcurrencyStamp = "3bf6de68-42a6-4486-8394-87da033828b9", Description = "Description", ... }
            var expectedAgenta = _testAgentas[0];
            _mockAgentaDal.Setup(m => m.Get(u => u.Id == expectedAgenta.Id)).Returns(expectedAgenta);

            
            var actualAgenta = _agentaManager.Get(expectedAgenta.Id);//burda patlıyor null donuyor

           
            Assert.Equal(expectedAgenta, actualAgenta);
        }

        [Fact]
        public void Get_ShouldReturnNull_WhenIdIsNotValid()
        {
            
            var invalidId = -1;
            _mockAgentaDal.Setup(m => m.Get(u => u.Id == invalidId)).Returns((Agenta)null);

            
            var actualAgenta = _agentaManager.Get(invalidId);

            
            Assert.Null(actualAgenta);
        }

        [Fact]
        public void GetListAgenta_ShouldReturnTheCorrectListOfAgentas()
        {
            
            var expectedAgentas = _testAgentas;
            _mockAgentaDal.Setup(m => m.GetList(null)).Returns(expectedAgentas);

            
            var actualAgentas = _agentaManager.GetListAgenta();

            
            Assert.Equal(expectedAgentas, actualAgentas);
        }

        [Fact]
        public void Update_ShouldCallUpdateMethodOfAgentaDal_WhenAgentaIsValid()
        {
            
            var existingAgenta = _testAgentas[0];
            existingAgenta.UnitName = "Alice Smith";
            _mockAgentaDal.Setup(m => m.Get(u => u.Id == existingAgenta.Id)).Returns(existingAgenta);

            
            _agentaManager.Update(existingAgenta);

            
            _mockAgentaDal.Verify(m => m.Update(existingAgenta), Times.Once);
        }
    }
}
