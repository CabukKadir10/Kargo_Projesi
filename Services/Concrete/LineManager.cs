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
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class LineManager : ILineService
    {
        private readonly IDalManager _dalManager;
        private readonly ILoggerService _logger;
        private readonly IStationService _services;

        public LineManager(IDalManager dalManager, ILoggerService logger, IStationService services)
        {
            _dalManager = dalManager;
            _logger = logger;
            _services = services;
        }

        [ValidationAspects(typeof(LineValidator))]
        public IResult Add(Line line)
        {
            int i;
            _dalManager.LineDal.Create(line);
            for ( i = 0; i < line.Stations.Count; i++)
            {
                var station = line.Stations[i];
                station.OrderNumber = i + 1;
                _services.Add(station);
            }

            

            return new SuccessResult();
        }

        public IResult Delete(Line line)
        {
            _dalManager.LineDal.Delete(line);
            return new SuccessResult();
        }

        public IDataResult<Line> GetByIdLine(int id)
        {
            return new SuccessDataResult<Line>(_dalManager.LineDal.Get(u => u.LineId == id));
        }

        public IDataResult<List<Line>> GetListLine()
        {
            return new SuccessDataResult<List<Line>>(_dalManager.LineDal.GetList());
        }

        [ValidationAspects(typeof(LineValidator))]
        public IResult Update(Line line)
        {
            _dalManager.LineDal.Update(line);
            return new SuccessResult();
        }
    }
}
