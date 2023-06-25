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
    public class AgentaManager : IAgentaService
    {
        private readonly IDalManager _dalManager;

        public AgentaManager(IDalManager dalManager)
        {
            _dalManager = dalManager;
        }

        public IResult Add(Agenta agenta)
        {
            _dalManager.AgentaDal.Create(agenta);
            return new SuccessResult();
        }

        public IResult Delete(Agenta agenta)
        {
            _dalManager.AgentaDal.Delete(agenta);
            return new SuccessResult();
        }

        public IDataResult<Agenta> GetByIdAgenta(int id)
        {
            return new SuccessDataResult<Agenta>(_dalManager.AgentaDal.Get(u => u.UnitId == id));
        }

        public IDataResult<List<Agenta>> GetListAgenta()
        {
            return new SuccessDataResult<List<Agenta>>(_dalManager.AgentaDal.GetList());
        }

        public IResult Update(Agenta agenta)
        {
            _dalManager.AgentaDal.Update(agenta);
            return new SuccessResult();
        }
    }
}
