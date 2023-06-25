using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Abstract
{
    public interface IDalManager
    {
        IAgentaDal AgentaDal { get; }
        ILineDal LineDal { get; }
        IStationDal StationDal { get; }
        ITransferCenterDal TransferCenterDal { get; }
    }
}
