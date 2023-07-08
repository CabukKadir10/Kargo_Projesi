using Core.Aspects.AutoFac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Data.Abstract;
using Entity.Concrete;
using Services.Abstract;
using Services.FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        [ValidationAspects(typeof(CenterValidator))]
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

        public IDataResult<TransferCenter> GetByIdCenter(Expression<Func<TransferCenter, bool>> filter)
        {
            return new SuccessDataResult<TransferCenter>(_dalManager.TransferCenterDal.Get(filter));
        }

        public IDataResult<List<TransferCenter>> GetListCenter()
        {
            return new SuccessDataResult<List<TransferCenter>>(_dalManager.TransferCenterDal.GetList());
        }

        [ValidationAspects(typeof(CenterValidator))]
        public IResult Update(TransferCenter transferCenter)
        {
            _dalManager.TransferCenterDal.Update(transferCenter);
            return new SuccessResult();
        }
    }
}
