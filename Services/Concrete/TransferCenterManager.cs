using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Data.Abstract;
using Entity.Concrete;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class TransferCenterManager : ITransferCenterService
    {
        private readonly IDalManager _dalManager;

        public TransferCenterManager(IDalManager dalManager)
        {
            _dalManager = dalManager;
        }

        public IResult Add(TransferCenter transferCenter)
        {
            _dalManager.TransferCenterDal.Create(transferCenter);
            return new SuccessResult();
        }

        public IResult Delete(TransferCenter transferCenter)
        {
            _dalManager.TransferCenterDal.Delete(transferCenter);
            return new SuccessResult();
        }

        public IDataResult<TransferCenter> GetByIdCenter(int id)
        {
            return new SuccessDataResult<TransferCenter>(_dalManager.TransferCenterDal.Get(u => u.UnitId == id));
        }

        public IDataResult<List<TransferCenter>> GetListCenter()
        {
            return new SuccessDataResult<List<TransferCenter>>(_dalManager.TransferCenterDal.GetList());
        }

        public IResult Update(TransferCenter transferCenter)
        {
            _dalManager.TransferCenterDal.Update(transferCenter);
            return new SuccessResult();
        }
    }
}
