using System;
using System.Collections.Generic;
using aiio.Domain.Models.Locations;
using aiio.Domain.Models.Resources;
using aiio.Domain.Models.Users;
using Xunit;
using FluentAssertions;
using aiio.Domain.Models.Departments;
using aiio.Domain.Models.Roles;
using aiio.Domain.Exceptions;

namespace aiio.Domain.Models.Processes.Tests
{
    public class ProcessTests
    {
        [Fact]
        public void Create_ShouldInitializeProcessWithGivenValues()
        {
            // Arrange
            var id = Guid.NewGuid();
            var title = "Test Process";
            var description = "Test Description";
            var user = User.Create(Guid.NewGuid(), "Test User");

            // Act
            var process = Process.Create(id, title, description, user);

            // Assert
            process.Id.Should().Be(id);
            process.Title.Should().Be(title);
            process.Description.Should().Be(description);
            process.CreatedBy.Should().Be(user);
        }

        [Fact]
        public void AddDepartment_ShouldAddDepartmentToProcess()
        {
            // Arrange
            var process = Process.Create(Guid.NewGuid(), "Test Process", null, User.Create(Guid.NewGuid(), "Test User"));
            var department = Department.Create(Guid.NewGuid(), "Test Department", User.Create(Guid.NewGuid(), "Creator"));

            // Act
            process.AddDepartment(department);

            // Assert
            process.Departments.Should().Contain(department);
        }

        [Fact]
        public void AddRole_ShouldAddRoleToProcess()
        {
            // Arrange
            var process = Process.Create(Guid.NewGuid(), "Test Process", null, User.Create(Guid.NewGuid(), "Test User"));
            var role = Role.Create(Guid.NewGuid(), "Test Role", User.Create(Guid.NewGuid(), "Creator"));

            // Act
            process.AddRole(role);

            // Assert
            process.Roles.Should().Contain(role);
        }

        [Fact]
        public void AddResource_ShouldAddResourceToProcess()
        {
            // Arrange
            var process = Process.Create(Guid.NewGuid(), "Test Process", null, User.Create(Guid.NewGuid(), "Test User"));
            var resource = Resource.Create(Guid.NewGuid(), "Test Resource", User.Create(Guid.NewGuid(), "Creator"));

            // Act
            process.AddResource(resource);

            // Assert
            process.Resources.Should().Contain(resource);
        }

        [Fact]
        public void AddLocation_ShouldAddLocationToProcess()
        {
            // Arrange
            var process = Process.Create(Guid.NewGuid(), "Test Process", null, User.Create(Guid.NewGuid(), "Test User"));
            var location = Location.Create(Guid.NewGuid(), "Test Location", User.Create(Guid.NewGuid(), "Creator"));

            // Act
            process.AddLocation(location);

            // Assert
            process.Locations.Should().Contain(location);
        }

        [Fact]
        public void ChangeTitle_ShouldUpdateTitle_WhenValidTitleIsProvided()
        {
            // Arrange
            var process = Process.Create(Guid.NewGuid(), "Old Title", null, User.Create(Guid.NewGuid(), "Test User"));
            var newTitle = "New Title";

            // Act
            process.ChangeTitle(newTitle);

            // Assert
            process.Title.Should().Be(newTitle);
        }

        [Fact]
        public void ChangeTitle_ShouldThrowException_WhenTitleIsNullOrEmpty()
        {
            // Arrange
            var process = Process.Create(Guid.NewGuid(), "Old Title", null, User.Create(Guid.NewGuid(), "Test User"));

            // Act
            Action act = () => process.ChangeTitle("");

            // Assert
            act.Should().Throw<DomainException>().WithMessage("Title cannot be null or empty.");
        }

        [Fact]
        public void ChangeDescription_ShouldUpdateDescription()
        {
            // Arrange
            var process = Process.Create(Guid.NewGuid(), "Test Process", "Old Description", User.Create(Guid.NewGuid(), "Test User"));
            var newDescription = "New Description";

            // Act
            process.ChangeDescription(newDescription);

            // Assert
            process.Description.Should().Be(newDescription);
        }
    }
}
