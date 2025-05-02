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
        public Guid CreatedById  { get; private set; }
        public User CreatedBy { get; private set; } = default!;
        public List<Department> Departments { get; private set; } = default!;
        public List<Role> Roles { get; private set; } = default!;
        public List<Resource> Resources { get; private set; } = default!;
        public List<Location> Locations { get; private set; } = default!;

        public static Process Create(Guid id, string title, string? description, User user)
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
    }
}
