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
            // Arrange
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
            // Arrange
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

            // Act
            _agentaManager.Add(newAgenta);

            // Assert
            _mockAgentaDal.Verify(m => m.Create(newAgenta), Times.Once);
        }

        [Fact]
        public void Add_ShouldNotCallCreateMethodOfAgentaDal_WhenAgentaIsValidAndCenterHasMoreThan10Agentas()
        {
            // Arrange
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

            // Act
            _agentaManager.Add(newAgenta);

            // Assert
            _mockAgentaDal.Verify(m => m.Create(newAgenta), Times.Never);
        }

        [Fact]
        public void Delete_ShouldCallDeleteMethodOfAgentaDal_WhenAgentaExists()
        {
            // Arrange
            var existingAgenta = _testAgentas[0];
            _mockAgentaDal.Setup(m => m.Get(u => u.Id == existingAgenta.Id)).Returns(existingAgenta);

            // Act
            _agentaManager.Delete(existingAgenta);

            // Assert
            _mockAgentaDal.Verify(m => m.Delete(existingAgenta), Times.Once);
        }

        [Fact]
        public void Delete_ShouldNotCallDeleteMethodOfAgentaDal_WhenAgentaDoesNotExist()
        {
            // Arrange
            var nonExistingAgenta = new Agenta
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
            _mockAgentaDal.Setup(m => m.Get(u => u.Id == nonExistingAgenta.Id)).Returns((Agenta)null);

            // Act
            _agentaManager.Delete(nonExistingAgenta);

            // Assert
            _mockAgentaDal.Verify(m => m.Delete(nonExistingAgenta), Times.Never);
        }

        [Fact]
        public void Get_ShouldReturnTheCorrectAgenta_WhenIdIsGiven()
        {
            // Arrange
            var expectedAgenta = _testAgentas[0];
            _mockAgentaDal.Setup(m => m.Get(u => u.Id == expectedAgenta.Id)).Returns(expectedAgenta);

            // Act
            var actualAgenta = _agentaManager.Get(expectedAgenta.Id);

            // Assert
            Assert.Equal(expectedAgenta, actualAgenta);
        }

        [Fact]
        public void Get_ShouldReturnNull_WhenIdIsNotValid()
        {
            // Arrange
            var invalidId = -1;
            _mockAgentaDal.Setup(m => m.Get(u => u.Id == invalidId)).Returns((Agenta)null);

            // Act
            var actualAgenta = _agentaManager.Get(invalidId);

            // Assert
            Assert.Null(actualAgenta);
        }

        [Fact]
        public void GetListAgenta_ShouldReturnTheCorrectListOfAgentas()
        {
            // Arrange
            var expectedAgentas = _testAgentas;
            _mockAgentaDal.Setup(m => m.GetList(null)).Returns(expectedAgentas);

            // Act
            var actualAgentas = _agentaManager.GetListAgenta();

            // Assert
            Assert.Equal(expectedAgentas, actualAgentas);
        }

        [Fact]
        public void Update_ShouldCallUpdateMethodOfAgentaDal_WhenAgentaIsValid()
        {
            // Arrange
            var existingAgenta = _testAgentas[0];
            existingAgenta.UnitName = "Alice Smith";
            _mockAgentaDal.Setup(m => m.Get(u => u.Id == existingAgenta.Id)).Returns(existingAgenta);

            // Act
            _agentaManager.Update(existingAgenta);

            // Assert
            _mockAgentaDal.Verify(m => m.Update(existingAgenta), Times.Once);
        }
    }
}
