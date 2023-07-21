using Autofac.Core;
using Core.Aspects.AutoFac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Data.Abstract;
using Entity.Concrete;
using Entity.Exceptions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
    public class AgentaManager : IAgentaService
    {
        private readonly IDalManager _dalManager;

        public AgentaManager(IDalManager dalManager)
        {
            _dalManager = dalManager;
        }

        [ValidationAspects(typeof(AgentaValidator))]
        public void Add(Agenta agenta)
        {
            var list = _dalManager.AgentaDal.Count(a => a.CenterId == agenta.CenterId);
            if(list< 10)
                _dalManager.AgentaDal.Create(agenta);
        }

        public void CancelDelete(int id)
        {
            var agenta = _dalManager.AgentaDal.Get(a => a.Id == id);
            if(agenta.IsDeleted == true)
            {
                agenta.IsDeleted = false;
                _dalManager.AgentaDal.Update(agenta);
            }
        }

        public void HardDelete(int id)
        {
            var getAgenta = _dalManager.AgentaDal.Get(a => a.Id == id);
            if (getAgenta is null)
                throw new AgentaNotFound(id);

            _dalManager.AgentaDal.Delete(getAgenta);
        }

        public Agenta Get(int id)
        {
            var agenta = _dalManager.AgentaDal.Get(a => a.Id == id);
            if (agenta is null)
                throw new AgentaNotFound(id);
            return agenta;
        }

        public Agenta GetByIdAgenta(Expression<Func<Agenta, bool>> filter)
        {
            var agenta = _dalManager.AgentaDal.Get(filter);
            if (agenta is null)
                throw new AgentaNotFound(agenta.Id);
            return agenta;
        }

        public List<Agenta> GetListAgenta()//burada kontrol et
        {
            return _dalManager.AgentaDal.GetList();
        }

        public void Delete(int id)
        {
            var agenta = _dalManager.AgentaDal.Get(a => a.Id == id);
            if(agenta.IsDeleted == false)
            {
                agenta.IsDeleted = true;
                _dalManager.AgentaDal.Update(agenta);
            }
        }

        [ValidationAspects(typeof(AgentaValidator))]
        public void Update(Agenta agenta)
        {
            var getAgenta = _dalManager.AgentaDal.Get(a => a.Id == agenta.Id);
            if (getAgenta is null)
                throw new AgentaNotFound(agenta.Id);

            _dalManager.AgentaDal.Update(agenta);
        }
        
    }
}
