using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Controllers;

namespace TestProject1
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        private readonly IServiceManager _serviceManager;

        public CustomWebApplicationFactory(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        public CustomWebApplicationFactory()
        {
        }
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseStartup<TStartup>();
            builder.ConfigureTestServices(services =>
            {
                services.AddSingleton(_serviceManager);
            });
        }
    }
}
