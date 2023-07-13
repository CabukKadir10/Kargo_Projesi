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
using WebApi.Controllers;
using Microsoft.AspNetCore.Hosting;
using Services.Abstract;
using Services.Concrete;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace TestProject1
{
    public class Deneme2
    {
        private readonly CustomWebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;

        public Deneme2(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task CreateAgenta_WithValidData_CreatesAgenta()
        {
            var factory = new CustomWebApplicationFactory<Program>();
            var client = factory.CreateClient();
            // Arrange
            //var createAgentaDto = new CreateAgentaDto
            //{
            //    UnitName = "deneme",
            //    Email = "deneme@gmail.com",
            //    Gsm = "0864576",
            //    PhoneNumber = "05393185301",
            //    CenterId = 1
            //};

            // Act
            var response = await client.GetAsync("/api/Station/GetListStation");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            //var createdAgenta = JsonConvert.DeserializeObject<Agenta>(await response.Content.ReadAsStringAsync());

            // Assert the properties of the createdAgenta object
           // Assert.NotNull(createdAgenta);
            //Assert.Equal(createAgentaDto.UnitName, createdAgenta.UnitName);
            //Assert.Equal(createAgentaDto.Email, createdAgenta.Email);
            // Assert other properties

            // Cleanup (optional)
            // If necessary, you can delete the created Agenta object to clean up the database or any resources used during the test.
        }
        //private readonly AgentaController _agentaController;

        //public Deneme2(AgentaController agentaController)
        //{
        //    _agentaController = agentaController;
        //}

        //[Fact]
        //public void Deneme()
        //{
        //    var result = _agentaController.GetByIdAgenta(8);

        //    Assert.NotNull(result);
        //    Assert.True(result.Equals(8));
        //}
    }
}
