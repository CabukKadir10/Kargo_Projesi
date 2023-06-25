using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface ITransferCenterService
    {
        IResult Add(TransferCenter transferCenter);
        IResult Update(TransferCenter transferCenter);
        IResult Delete(TransferCenter transferCenter);
        IDataResult<TransferCenter> GetByIdCenter(int id);
        IDataResult<List<TransferCenter>> GetListCenter();
    }
}
