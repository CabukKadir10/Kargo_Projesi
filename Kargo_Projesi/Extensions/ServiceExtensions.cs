using Data.Abstract;
using Data.Concrete;
using Data.Concrete.EfCore.Context;
using Microsoft.EntityFrameworkCore;
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
            services.AddScoped<IUserService, UserManager>();
        }

        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddSingleton<ILoggerService, LoggerManager>();

        public static void ConfigureContextKargo(this IServiceCollection services)
        {
            services.AddDbContext<ContextKargo>(options => options.UseNpgsql("ConnectionStrings"));
        }
    }
}
