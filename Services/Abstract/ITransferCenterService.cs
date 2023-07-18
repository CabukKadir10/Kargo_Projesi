using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface ITransferCenterService
    {
        IResult Add(TransferCenter transferCenter);
        IResult Update(TransferCenter transferCenter);
        IResult HardDelete(int id);
        IResult CancelDelete(int id);
        IResult Delete(int id);
        IDataResult<TransferCenter> GetByIdCenter(Expression<Func<TransferCenter, bool>> filter);
        IDataResult<List<TransferCenter>> GetListCenter();
    }
}
