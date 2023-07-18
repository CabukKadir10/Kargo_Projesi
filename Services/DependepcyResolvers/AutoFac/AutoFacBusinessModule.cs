using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.Jwt;
using Data.Abstract;
using Data.Concrete;
using Services.Abstract;
using Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DependepcyResolvers.AutoFac
{
    public class AutoFacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LineDal>().As<ILineDal>();
            builder.RegisterType<AgentaDal>().As<IAgentaDal>();
            builder.RegisterType<StationDal>().As<IStationDal>();
            builder.RegisterType<TransferCenterDal>().As<ITransferCenterDal>();
            builder.RegisterType<RoleDal>().As<IRoleDal>();
            builder.RegisterType<UserDal>().As<IUserDal>();

            builder.RegisterType<DalManager>().As<IDalManager>();
            builder.RegisterType<ServiceManager>().As<IServiceManager>();

            builder.RegisterType<LineManager>().As<ILineService>();
            builder.RegisterType<AgentaManager>().As<IAgentaService>();
            builder.RegisterType<StationManager>().As<IStationService>();
            builder.RegisterType<TransferCenterManager>().As<ITransferCenterService>();
            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<MailManager>().As<IMailService>();
            builder.RegisterType<RoleManager>().As<IRoleService>();
            builder.RegisterType<UserManagerr>().As<IUserService>();

            builder.RegisterType<TokenHelper>().As<ITokenHelper>();
            builder.RegisterType<LoggerManager>().As<ILoggerService>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
