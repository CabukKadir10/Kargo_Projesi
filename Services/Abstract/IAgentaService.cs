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
    public interface IAgentaService
    {
        void Add(Agenta agenta);
        void Update(Agenta agenta);
        void HardDelete(int id);
        Agenta GetByIdAgenta(Expression<Func<Agenta, bool>> filter);
        List<Agenta> GetListAgenta();
        Agenta Get(int id);
        void CancelDelete(int id);
        void Delete(int id);
    }
}
