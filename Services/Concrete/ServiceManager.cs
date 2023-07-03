using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class ServiceManager : IServiceManager
    {
        private readonly IAgentaService _agentaService;
        private readonly ILineService _lineService;
        private readonly IStationService _stationService;
        private readonly ITransferCenterService _transferCenterService;
        private readonly IUserService _userService;

        public ServiceManager(IAgentaService agentaService, ILineService lineService, IStationService stationService, ITransferCenterService transferCenterService, IUserService userService)
        {
            _agentaService = agentaService;
            _lineService = lineService;
            _stationService = stationService;
            _transferCenterService = transferCenterService;
            _userService = userService;
        }

        public IAgentaService AgentaService => _agentaService;

        public ILineService LineService => _lineService;

        public IStationService StationService => _stationService;

        public ITransferCenterService TransferCenterService => _transferCenterService;

        public IUserService UserService => _userService;
    }
}
