using Xunit;
using Moq;
using Services;
using Repositories;
using Models;

namespace EmployeeApi.Tests.Services
{
    public class EmployeeServiceTests
    {
        [Fact]
        public async Task CreateEmployee_ShouldReturnCreatedEmployee()
        {
            // Arrange
            var mockRepo = new Mock<IEmployeeRepository>();
            var service = new EmployeeService(mockRepo.Object);

            var employee = new Employee
            {
                Id = 1,
                Name = "Budi",
                Position = "Developer",
                Salary = 8000000
            };

            mockRepo.Setup(r => r.Create(employee))
                    .ReturnsAsync(employee);

            // Act
            var result = await service.Create(employee);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Budi", result.Name);
        }
    }
}