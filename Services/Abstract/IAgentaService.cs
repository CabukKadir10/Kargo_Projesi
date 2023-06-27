using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IAgentaService
    {
        void Add(Agenta agenta);
        void Update(Agenta agenta);
        void Delete(Agenta agenta);
        Agenta GetByIdAgenta(int id);
        List<Agenta> GetListAgenta();
        Agenta Get(int id);

        //IResult Add(Agenta agenta);
        //IResult Update(Agenta agenta);
        //IResult Delete(Agenta agenta);
        //IDataResult<Agenta> GetByIdAgenta(int id);
        //IDataResult<List<Agenta>> GetListAgenta();
    }
}
