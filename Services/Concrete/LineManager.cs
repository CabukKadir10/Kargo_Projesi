using AutoMapper;
using Core.Aspects.AutoFac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Data.Abstract;
using Entity.Concrete;
using Entity.Concrete.Enum;
using Entity.Dto;
using Entity.Exceptions;
using Services.Abstract;
using Services.Constans;
using Services.FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class LineManager : ILineService
    {
        private readonly IDalManager _dalManager;
        private readonly ILoggerService _logger;
        private readonly IStationService _services;
        private readonly IMapper _mapper;

        public LineManager(IDalManager dalManager, ILoggerService logger, IStationService services, IMapper mapper)
        {
            _dalManager = dalManager;
            _logger = logger;
            _services = services;
            _mapper = mapper;
        }

        [ValidationAspects(typeof(LineValidator))]
        public IResult Add(CreateLineDto createLineDto)
        {
            var line = _mapper.Map<Line>(createLineDto);
            _dalManager.LineDal.Create(line);

            var stations = new List<Station>();

            if(createLineDto.CenterId != 0)
            {
                var station = new Station
                {
                    StationName = $"{line.LineName}",
                    OrderNumber = 1,
                    LineId = line.LineId,
                    IsActive = true,
                    UnitId = createLineDto.CenterId
                };

                stations.Add(station);
                
            }

            foreach (var stationUnitId in createLineDto.Station)
            {
                var station = new Station
                {
                    StationName = $"{line.LineName} Durak {stations.Count + 1}",
                    OrderNumber = stations.Count + 1,
                    LineId = line.LineId,
                    IsActive = true,
                    UnitId = stationUnitId
                };
                stations.Add(station);
            }

            _services.AddRange(stations);
            return new SuccessResult(Messages.CreatedLine);

            //if (createLineDto.CenterId != 0)
            //{
            //    var lastStation = new Station
            //    {
            //        StationName = $"{line.LineName}",
            //        OrderNumber = 1,
            //        LineId = line.LineId,
            //        IsActive = true,
            //        UnitId = line.CenterId
            //    };
            //    _dalManager.StationDal.Create(lastStation);

            //    for (int i = 0; i < createLineDto.Station.Length; i++)
            //    {
            //        var station = new Station
            //        {
            //            StationName = $"{line.LineName} Durak {i + 2}",
            //            OrderNumber = i + 2,
            //            LineId = line.LineId,
            //            IsActive = true,
            //            UnitId = createLineDto.Station[i]
            //        };
            //        _services.Add(station);
            //    }
            //}
            //else
            //{
            //    for (int i = 0; i < createLineDto.Station.Length; i++)
            //    {
            //        var station = new Station
            //        {
            //            StationName = $"{line.LineName} Durak {i + 1}",
            //            OrderNumber = i + 1,
            //            LineId = line.LineId,
            //            IsActive = true,
            //            UnitId = createLineDto.Station[i]
            //        };

            //        _services.Add(station);
            //    }
            //}
            //return new SuccessResult(Messages.CreatedLine);
        }

        public IResult Delete(int id)
        {
            var getLine = _dalManager.LineDal.Get(a => a.LineId == id);
            if (getLine is null)
                throw new LineNotFound(id);

            _dalManager.LineDal.Delete(getLine);
            return new SuccessResult(Messages.DeletedLine);
        }

        public IDataResult<Line> GetByIdLine(int id)
        {
            var getByLine = _dalManager.LineDal.Get(a => a.LineId == id);
            if (getByLine is null)
                throw new LineNotFound(id);

            return new SuccessDataResult<Line>(getByLine);
        }

        public IDataResult<List<Line>> GetListByIdUserLine(int id)
        {
            //var lineList=new List<Line>();
            //var lines = _dalManager.LineDal.GetList();
            //foreach (var line in lines)
            //{ 
            //    var stations= _dalManager.StationDal.GetList(u => u.LineId == line.LineId);
            //    if (stations.Any(s => s.UnitId == id))
            //        lineList.Add(line);
            //}
            //return new SuccessDataResult<List<Line>>(lineList);


            var listLine = new List<Line>();
            var listLineId = new List<int>();
            var deneme = _dalManager.StationDal.GetList(a => a.UnitId == id);
            for (int i = 0; i < deneme.Count; i++)
            {
                listLineId.Add(deneme[i].LineId);

            }

            for (int i = 0; i < listLineId.Count; i++)
            {
                listLine.Add(_dalManager.LineDal.Get(a => a.LineId == listLineId[i]));
            }

            return new SuccessDataResult<List<Line>>(listLine);
        }

        public IDataResult<List<Line>> GetListFilter(Expression<Func<Line, bool>> filter = null)
        {
            return new SuccessDataResult<List<Line>>(_dalManager.LineDal.GetList(filter));
        }

        public IDataResult<List<Line>> GetListLine()
        {
            return new SuccessDataResult<List<Line>>(_dalManager.LineDal.GetList());
        }

        [ValidationAspects(typeof(LineValidator))]
        public IResult Update(Line line)
        {
            var getLine = _dalManager.LineDal.Get(a => a.LineId == line.LineId);
            if (getLine is null)
                throw new LineNotFound(line.LineId);
            _dalManager.LineDal.Update(line);
            return new SuccessResult(Messages.UpdatedLine);
        }
    }
}
