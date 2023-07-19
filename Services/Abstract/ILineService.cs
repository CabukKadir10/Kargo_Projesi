using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface ILineService
    {
        IResult Add(CreateLineDto createLineDto);
        IResult Update(Line line);
        IResult Delete(int id);
        IDataResult<Line> GetByIdLine(int id);
        IDataResult<List<Line>> GetListLine();
        IDataResult<List<Line>> GetListFilter(Expression<Func<Line, bool>> filter = null);
        IDataResult<List<Line>> GetListByIdUserLine(int id);
    }
}
