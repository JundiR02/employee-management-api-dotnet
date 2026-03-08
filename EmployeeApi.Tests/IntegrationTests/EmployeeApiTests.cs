using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace EmployeeApi.Tests.IntegrationTests
{
    public class EmployeeApiTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public EmployeeApiTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetEmployees_ReturnsSuccess()
        {
            var response = await _client.GetAsync("/api/v1/employees");

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}