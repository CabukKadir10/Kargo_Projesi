using Data.Abstract;
using Data.Concrete.EfCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete
{
    public class DalManager : IDalManager
    {
        private readonly IAgentaDal _agentaDal;
        private readonly ILineDal _lineDal;
        private readonly IStationDal _stationDal;
        private readonly ITransferCenterDal _transferCenterDal;

        public DalManager(IAgentaDal agentaDal, ILineDal lineDal, IStationDal stationDal, ITransferCenterDal transferCenterDal)
        {
            _agentaDal = agentaDal;
            _lineDal = lineDal;
            _stationDal = stationDal;
            _transferCenterDal = transferCenterDal;
        }

        public IAgentaDal AgentaDal => _agentaDal;

        public ILineDal LineDal => _lineDal;

        public IStationDal StationDal => _stationDal;

        public ITransferCenterDal TransferCenterDal => _transferCenterDal;
    }
}
