using aiio.Domain.Models.Departments;
using aiio.Domain.Models.Locations;
using aiio.Domain.Models.Processes;
using aiio.Domain.Models.Resources;
using aiio.Domain.Models.Roles;
using aiio.Domain.Models.Users;
using aiio.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace aiio.Infrastructure.Repositories.Tests
{
    public class ProcessRepositoryTests
    {
        private readonly DbContextOptions<AiioDbContext> _dbContextOptions;

        public ProcessRepositoryTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<AiioDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
        }

        [Fact]
        public async Task Add_ShouldAddProcessToDatabase()
        {
            // Arrange
            var user = User.Create(Guid.NewGuid(), "Test User");
            var process = Process.Create(Guid.NewGuid(), "Test Process", "Test Description", user);
            using var context = new AiioDbContext(_dbContextOptions);
            var repository = new ProcessRepository(context);

            // Act
            var result = await repository.Add(process);
            await context.SaveChangesAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(process.Id, result.Id);
            Assert.Single(context.Processes);
        }

        [Fact]
        public async Task FindById_ShouldReturnProcess_WhenProcessExists()
        {
            // Arrange
            var user = User.Create(Guid.NewGuid(), "Test User");
            var process = Process.Create(Guid.NewGuid(), "Test Process", "Test Description", user);
            using var context = new AiioDbContext(_dbContextOptions);
            context.Processes.Add(process);
            await context.SaveChangesAsync();
            var repository = new ProcessRepository(context);

            // Act
            var result = await repository.FindById(process.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(process.Id, result.Id);
        }

        [Fact]
        public async Task FindById_ShouldReturnNull_WhenProcessDoesNotExist()
        {
            // Arrange
            using var context = new AiioDbContext(_dbContextOptions);
            var repository = new ProcessRepository(context);

            // Act
            var result = await repository.FindById(Guid.NewGuid());

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetAllProcessesAsync_ShouldReturnAllProcesses()
        {
            // Arrange
            var user = User.Create(Guid.NewGuid(), "Test User");
            var process1 = Process.Create(Guid.NewGuid(), "Process 1", "Description 1", user);
            var process2 = Process.Create(Guid.NewGuid(), "Process 2", "Description 2", user);
            using var context = new AiioDbContext(_dbContextOptions);
            context.Processes.AddRange(process1, process2);
            await context.SaveChangesAsync();
            var repository = new ProcessRepository(context);

            // Act
            var result = await repository.GetAllProcessesAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task GetProcessDetailAsync_ShouldReturnProcessWithDetails_WhenProcessExists()
        {
            // Arrange
            var user = User.Create(Guid.NewGuid(), "Test User");
            var process = Process.Create(Guid.NewGuid(), "Test Process", "Test Description", user);

            var resource = Resource.Create(Guid.NewGuid(), "Resource 1", user);
            var location = Location.Create(Guid.NewGuid(), "Location 1", user);
            var department = Department.Create(Guid.NewGuid(), "Department 1", user);
            var role = Role.Create(Guid.NewGuid(), "Role 1", user);

            process.AddResource(resource);
            process.AddLocation(location);
            process.AddDepartment(department);
            process.AddRole(role);

            using var context = new AiioDbContext(_dbContextOptions);
            context.Processes.Add(process);
            await context.SaveChangesAsync();
            var repository = new ProcessRepository(context);

            // Act
            var result = await repository.GetProcessDetailAsync(process.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(process.Id, result.Id);
            Assert.NotEmpty(result.Resources);
            Assert.NotEmpty(result.Locations);
            Assert.NotEmpty(result.Departments);
            Assert.NotEmpty(result.Roles);
            Assert.NotNull(result.CreatedBy);
        }

        [Fact]
        public async Task GetProcessDetailAsync_ShouldReturnNull_WhenProcessDoesNotExist()
        {
            // Arrange
            using var context = new AiioDbContext(_dbContextOptions);
            var repository = new ProcessRepository(context);

            // Act
            var result = await repository.GetProcessDetailAsync(Guid.NewGuid());

            // Assert
            Assert.Null(result);
        }
    }
}
