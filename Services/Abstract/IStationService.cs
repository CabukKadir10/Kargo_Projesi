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
    public interface IStationService
    {
        void Add(Station station);
        IResult Update(Station station);
        IResult Delete(int id);
        IDataResult<Station> GetByIdStation(int id);
        IDataResult<List<Station>> GetListStation();
        IDataResult<List<Station>> GetListStation2(Expression<Func<Station, bool>> filter = null);
    }
}
