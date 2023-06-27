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
    public class LineManager : ILineService
    {
        private readonly IDalManager _dalManager;
        private readonly ILoggerService _logger;

        public LineManager(IDalManager dalManager, ILoggerService logger)
        {
            _dalManager = dalManager;
            _logger = logger;
        }

        public IResult Add(Line line)
        {
            _dalManager.LineDal.Create(line);
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

        public IResult Update(Line line)
        {
            _dalManager.LineDal.Update(line);
            return new SuccessResult();
        }
    }
}
