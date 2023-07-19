using Core.Utilities.Results.Concrete;
using Data.Abstract;
using Entity.Concrete;
using Moq;
using Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public class TransferCenterManagerTests
    {
        private readonly Mock<IDalManager> _mockDalManager;
        private readonly TransferCenterManager _transferCenterManager;

        public TransferCenterManagerTests()
        {
            
            _mockDalManager = new Mock<IDalManager>();

            
            _transferCenterManager = new TransferCenterManager(_mockDalManager.Object);
        }

        [Fact]
        public void Add_WhenCalledWithValidTransferCenter_ReturnsSuccessResult()
        {
           
            var transferCenter = new TransferCenter
            {
                Id = 1,
                UnitName = "Name1",
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
                IsDeleted = false,
                AddressDetail = "Amed merkez"
            };

            var expected = new SuccessResult();

           
            _mockDalManager.Setup(m => m.TransferCenterDal.Create(transferCenter)).Verifiable();

            
            var actual = _transferCenterManager.Add(transferCenter);

           
            Assert.Equal(expected.Success, actual.Success);
            Assert.Equal(expected.Message, actual.Message);
            _mockDalManager.Verify();
        }

        //[Fact]
        //public void Delete_WhenCalledWithValidTransferCenter_ReturnsSuccessResult()
        //{
            
        //    var transferCenter = new TransferCenter
        //    {
        //        Id = 1,
        //        UnitName = "Name1",
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
        //        IsDeleted = false,
        //        AddressDetail = "Amed merkez"
        //    };

        //    var expected = new SuccessResult();

            
        //    _mockDalManager.Setup(m => m.TransferCenterDal.Delete(transferCenter)).Verifiable();

           
        //    var actual = _transferCenterManager.Delete(transferCenter);

           
        //    Assert.Equal(expected.Success, actual.Success);
        //    Assert.Equal(expected.Message, actual.Message);
        //    _mockDalManager.Verify();
        //}

        [Fact]
        public void GetByIdCenter_WhenCalledWithValidFilter_ReturnsSuccessDataResult()
        {
            
            Expression<Func<TransferCenter, bool>> filter = t => t.Id == 1;

            var transferCenter = new TransferCenter
            {
                Id = 1,
                UnitName = "Name1",
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
                IsDeleted = false,
                AddressDetail = "Amed merkez"
            };

            var expected = new SuccessDataResult<TransferCenter>(transferCenter);

            
            _mockDalManager.Setup(m => m.TransferCenterDal.Get(filter)).Returns(transferCenter).Verifiable();

            
            var actual = _transferCenterManager.GetByIdCenter(filter);

            
            Assert.Equal(expected.Success, actual.Success);
            Assert.Equal(expected.Message, actual.Message);
            Assert.Equal(expected.Data, actual.Data);
            _mockDalManager.Verify();
        }

        [Fact]
        public void GetListCenter_WhenCalled_ReturnsSuccessDataResult()
        {
            
            var transferCenters = new List<TransferCenter>
            {
                new TransferCenter
                    {
                        Id = 1,
                        UnitName = "Name1",
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
                        IsDeleted = false,
                        AddressDetail = "Amed merkez"
                    },
                    new TransferCenter
                    {
                        Id = 2,
                        UnitName = "Name2",
                        ManagerName = "muaz",
                        ManagerSurname = "Çabuk",
                        PhoneNumber = "05123456789",
                        Gsm = "085012356",
                        Email = "muaz@gmail.com",
                        Description = "Description",
                        City = "Mardin",
                        District = "Bağlar",
                        NeighBourHood = "mahalle1",
                        Street = "sokak1",
                        IsDeleted = false,
                        AddressDetail = "Mardin merkez"
                    },
                    new TransferCenter
                    {
                        Id = 3,
                        UnitName = "Name3",
                        ManagerName = "yusuf",
                        ManagerSurname = "Çabuk",
                        PhoneNumber = "05123456789",
                        Gsm = "085012356",
                        Email = "yusuf@gmail.com",
                        Description = "Description",
                        City = "Konya",
                        District = "Bağlar",
                        NeighBourHood = "mahalle1",
                        Street = "sokak1",
                        IsDeleted = false,
                        AddressDetail = "Konya merkez"
                    }

            };

            var expected = new SuccessDataResult<List<TransferCenter>>(transferCenters);

            
            _mockDalManager.Setup(m => m.TransferCenterDal.GetList(null)).Returns(transferCenters).Verifiable();

           
            var actual = _transferCenterManager.GetListCenter();

           
            Assert.Equal(expected.Success, actual.Success);
            Assert.Equal(expected.Message, actual.Message);
            Assert.Equal(expected.Data, actual.Data);
            _mockDalManager.Verify();
        }
    }
}
