using Entity.Concrete;
using Entity.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net.Http;

namespace Test
{
    public class AgentaControllerTests
    {

        //private CustomWebApplicationFactory _factory;
        private HttpClient _httpClient;

        public AgentaControllerTests()
        {
            //_factory = new CustomWebApplicationFactory();
            var webApplicationFactory = new WebApplicationFactory<Program>();
            _httpClient = webApplicationFactory.CreateDefaultClient();
        }

        [Fact]
        public async Task CustomerGet_ReturnsListOfCustomers()
        {
            var response = await _httpClient.GetAsync("/api/Agenta/CreateAgenta");
            var result = await response.Content.ReadAsStringAsync();

            Assert.True(!string.IsNullOrEmpty(result));
            Assert.True(result.Length > 0);
        }
    }

}
