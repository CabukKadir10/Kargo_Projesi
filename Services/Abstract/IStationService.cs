using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IStationService
    {
        IResult Add(Station station);
        IResult Update(Station station);
        IResult Delete(Station station);
        IDataResult<Station> GetByIdStation(int id);
        IDataResult<List<Station>> GetListStation();
    }
}
