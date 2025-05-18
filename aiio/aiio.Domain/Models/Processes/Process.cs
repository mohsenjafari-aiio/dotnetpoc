using aiio.Domain.Exceptions;
using aiio.Domain.Models.Departments;
using aiio.Domain.Models.Locations;
using aiio.Domain.Models.Resources;
using aiio.Domain.Models.Roles;
using aiio.Domain.Models.Users;
using aiio.Framework.BaseModel;

namespace aiio.Domain.Models.Processes
{
    public class Process : BaseModel
    {
        public string? Description { get; private set; }
        public int CreatedById { get; private set; }
        public User CreatedBy { get; private set; } = default!;
        public List<Department> Departments { get; private set; } = default!;
        public List<Role> Roles { get; private set; } = default!;
        public List<Resource> Resources { get; private set; } = default!;
        public List<Location> Locations { get; private set; } = default!;

        public static Process Create(int id, string title, string? description, User user)
        {
            var process = new Process
            {
                Id = id,
                Title = title,
                Description = description,
                CreatedBy = user
            };
            return process;
        }

        public void AddDepartment(Department department)
        {
            if (Departments == null)
            {
                Departments = new List<Department>();
            }
            Departments.Add(department);
        }

        public void AddRole(Role role)
        {
            if (Roles == null)
            {
                Roles = new List<Role>();
            }
            Roles.Add(role);
        }

        public void AddResource(Resource resource)
        {
            if (Resources == null)
            {
                Resources = new List<Resource>();
            }
            Resources.Add(resource);
        }

        public void AddLocation(Location location)
        {
            if (Locations == null)
            {
                Locations = new List<Location>();
            }
            Locations.Add(location);
        }

        public void ChangeTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new DomainException("Title cannot be null or empty.");
            }
            Title = title;
        }

        public void ChangeDescription(string? discription)
        {
            Description = discription;
        }
    }
}
