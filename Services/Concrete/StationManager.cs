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
    public class StationManager : IStationService
    {
        private readonly IDalManager _dalManager;

        public StationManager(IDalManager dalManager)
        {
            _dalManager = dalManager;
        }

        public IResult Add(Station station)
        {
            _dalManager.StationDal.Create(station);
            return new SuccessResult();
        }

        public IResult Delete(Station station)
        {
            _dalManager.StationDal.Delete(station);
            return new SuccessResult();
        }

        public IDataResult<Station> GetByIdStation(int id)
        {
            return new SuccessDataResult<Station>(_dalManager.StationDal.Get(u => u.Id == id));
        }

        public IDataResult<List<Station>> GetListStation()
        {
            return new SuccessDataResult<List<Station>>(_dalManager.StationDal.GetList());
        }

        public IResult Update(Station station)
        {
            _dalManager.StationDal.Update(station);
            return new SuccessResult();
        }
    }
}
