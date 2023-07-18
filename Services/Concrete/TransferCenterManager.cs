using Core.Aspects.AutoFac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Data.Abstract;
using Entity.Concrete;
using Entity.Exceptions;
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

        public IResult HardDelete(int id)
        {
            var center = _dalManager.TransferCenterDal.Get(a => a.Id == id);
            if (center is null)
                throw new CenterNotFound(id);

            _dalManager.TransferCenterDal.Delete(center);
            return new SuccessResult();
        }

        public IDataResult<TransferCenter> GetByIdCenter(Expression<Func<TransferCenter, bool>> filter)
        {
            var center = _dalManager.TransferCenterDal.Get(filter);
            if (center is null)
                throw new CenterNotFound(center.Id);

            return new SuccessDataResult<TransferCenter>(center);
        }

        public IDataResult<List<TransferCenter>> GetListCenter()
        {
            return new SuccessDataResult<List<TransferCenter>>(_dalManager.TransferCenterDal.GetList());
        }

        [ValidationAspects(typeof(CenterValidator))]
        public IResult Update(TransferCenter transferCenter)
        {
            var center = _dalManager.TransferCenterDal.Get(a => a.Id == transferCenter.Id);
            if (center is null)
                throw new CenterNotFound(transferCenter.Id);

            _dalManager.TransferCenterDal.Update(transferCenter);
            return new SuccessResult();
        }

        public IResult CancelDelete(int id)
        {
            var center = _dalManager.TransferCenterDal.Get(a => a.Id == id);
            if (center is null)
                throw new CenterNotFound(id);
            if(center.IsDeleted == true)
            {
                center.IsDeleted = false;
                _dalManager.TransferCenterDal.Update(center);
            }

            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
            var center = _dalManager.TransferCenterDal.Get(a => a.Id == id);
            if (center is null)
                throw new CenterNotFound(id);

            if(center.IsDeleted == false)
            {
                center.IsDeleted = true;
                _dalManager.TransferCenterDal.Update(center);
            }
            return new SuccessResult();
        }
    }
}
