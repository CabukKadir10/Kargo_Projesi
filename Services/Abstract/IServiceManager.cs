using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IServiceManager
    {
        IAgentaService AgentaService { get; }
        ILineService LineService { get; }
        IStationService StationService { get; }
        ITransferCenterService TransferCenterService { get; }
        IUserService UserService { get; }
    }
}
