using Data.Abstract;
using Data.Concrete;
using Services.Abstract;
using Services.Concrete;
using System.Xml.Serialization;

namespace WebApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureServiceRegister(this IServiceCollection services)
        {
            services.AddScoped<ILineDal, LineDal>();
            services.AddScoped<IAgentaDal, AgentaDal>();
            services.AddScoped<IStationDal, StationDal>();
            services.AddScoped<ITransferCenterDal, TransferCenterDal>();

            services.AddScoped<IDalManager, DalManager>();
            services.AddScoped<IServiceManager, ServiceManager>();

            services.AddScoped<ILineService, LineManager>();
            services.AddScoped<IAgentaService, AgentaManager>();
            services.AddScoped<IStationService, StationManager>();
            services.AddScoped<ITransferCenterService, TransferCenterManager>();
        }
    }
}
