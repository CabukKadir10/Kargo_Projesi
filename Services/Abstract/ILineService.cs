using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface ILineService
    {
        IResult Add(Line line);
        IResult Update(Line line);
        IResult Delete(Line line);
        IDataResult<Line> GetByIdLine(int id);
        IDataResult<List<Line>> GetListLine();
    }
}
