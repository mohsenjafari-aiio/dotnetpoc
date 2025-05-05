using aiio.Contract.Processes.Commands;
using aiio.Domain.Interfaces;
using aiio.Domain.Models.Processes;
using aiio.Domain.Models.Users;
using Moq;

namespace aiio.Application.Process.Commands.Handlers.Tests
{
    public class UpdateProcessHandlerTests
    {
        private readonly Mock<IProcessRepository> _processRepositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly UpdateProcessHandler _handler;

        public UpdateProcessHandlerTests()
        {
            _processRepositoryMock = new Mock<IProcessRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _handler = new UpdateProcessHandler(_processRepositoryMock.Object, _unitOfWorkMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnFailResult_WhenProcessNotFound()
        {
            // Arrange
            var command = new UpdateProcessCommand(Guid.NewGuid(), "New Title", "New Description");
            _processRepositoryMock.Setup(repo => repo.FindById(It.IsAny<Guid>())).ReturnsAsync((Domain.Models.Processes.Process)null);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Contains(result.Errors, e => e.Message == "Invalid process id");

            _processRepositoryMock.Verify(repo => repo.FindById(command.Id), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.SaveChangesAsync(), Times.Never);
        }

        [Fact]
        public async Task Handle_ShouldUpdateProcessAndReturnSuccessResult_WhenProcessExists()
        {
            // Arrange
            var processId = Guid.NewGuid();
            var user = User.Create(Guid.NewGuid(), "Test User"); // Assuming a valid User object is created here
            var process = Domain.Models.Processes.Process.Create(processId, "Old Title", "Old Description", user);

            var command = new UpdateProcessCommand(processId, "New Title", "New Description");

            _processRepositoryMock.Setup(repo => repo.FindById(It.IsAny<Guid>())).ReturnsAsync(process);
            _unitOfWorkMock.Setup(uow => uow.SaveChangesAsync()).ReturnsAsync(1);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Value);
            Assert.Equal(command.Title, result.Value.Process.Title);
            Assert.Equal(command.Description, result.Value.Process.Description);

            _processRepositoryMock.Verify(repo => repo.FindById(command.Id), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.SaveChangesAsync(), Times.Once);
        }
    }
}