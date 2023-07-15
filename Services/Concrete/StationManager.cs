using Core.Aspects.AutoFac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Data.Abstract;
using Entity.Concrete;
using Entity.Concrete.Enum;
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
    public class StationManager : IStationService
    {
        private readonly IDalManager _dalManager;

        public StationManager(IDalManager dalManager)
        {
            _dalManager = dalManager;
        }

        [ValidationAspects(typeof(StationValidator))]
        public void Add(Station station)
        {
            var line = _dalManager.LineDal.Get(a => a.LineId == station.LineId);
            var listStation = _dalManager.StationDal.GetList(a => a.LineId == station.LineId);
            var count = _dalManager.StationDal.Count(a => a.LineId == station.LineId);
            if(count <= 10)
            {
                if (line.LineType == LineType.outLine)
                {
                    var list = _dalManager.TransferCenterDal.GetList();
                    if (list.Any(a => a.Id == station.UnitId) && listStation.Any(a => a.UnitId != station.UnitId))
                    {
                        _dalManager.StationDal.Create(station);
                    }
                }
                else
                {
                    var list2 = _dalManager.AgentaDal.GetList();
                    if (list2.Any(a => a.Id == station.UnitId) && listStation.Any(a => a.UnitId != station.UnitId))
                    {
                        _dalManager.StationDal.Create(station);
                    }
                }
            }
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
            var stations = _dalManager.StationDal.GetList();
            return new SuccessDataResult<List<Station>>(stations);
        }

         public IDataResult<List<Station>> GetListStation2(Expression<Func<Station, bool>> filter = null)
        {
            return new SuccessDataResult<List<Station>>(_dalManager.StationDal.GetList(filter));
        }

        [ValidationAspects(typeof(StationValidator))]
        public IResult Update(Station station)
        {
            _dalManager.StationDal.Update(station);
            return new SuccessResult();
        }
    }
}
