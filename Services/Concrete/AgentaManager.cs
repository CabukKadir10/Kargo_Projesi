using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Data.Abstract;
using Entity.Concrete;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public void Add(Agenta agenta)
        {
            //var count = _dalManager.AgentaDal.Count(a => a.CenterId == agenta.CenterId);
            //if(count <= 5)
            _dalManager.AgentaDal.Create(agenta);
        }

        public void Delete(Agenta agenta)
        {
            _dalManager.AgentaDal.Delete(agenta);
        }

        public Agenta Get(int id)
        {
            return _dalManager.AgentaDal.Get(u => u.Id == id);
        }

        public Agenta GetByIdAgenta(Expression<Func<Agenta, bool>> filter)
        {
            return _dalManager.AgentaDal.Get(filter);
        }

        public List<Agenta> GetListAgenta()
        {
            return _dalManager.AgentaDal.GetList();
        }

        public void Update(Agenta agenta)

        {
            _dalManager.AgentaDal.Update(agenta);
        }
        //public IResult Add(Agenta agenta)
        //{
        //    _dalManager.AgentaDal.Create(agenta);
        //    return new SuccessResult();
        //}

        //public IResult Delete(Agenta agenta)
        //{
        //    _dalManager.AgentaDal.Delete(agenta);
        //    return new SuccessResult();
        //}

        //public Agenta Get(int id)
        //{
        //    return _dalManager.AgentaDal.Get(u => u.Id == id);
        //}

        //public IDataResult<Agenta> GetByIdAgenta(int id)
        //{
        //    return new SuccessDataResult<Agenta>(_dalManager.AgentaDal.Get(u => u.Id == id));
        //}

        //public IDataResult<List<Agenta>> GetListAgenta()
        //{
        //    return new SuccessDataResult<List<Agenta>>(_dalManager.AgentaDal.GetList());
        //}

        //public IResult Update(Agenta agenta)
        //{
        //    _dalManager.AgentaDal.Update(agenta);
        //    return new SuccessResult();
        //}
    }
}
