using aiio.Domain.Models.Departments;
using aiio.Domain.Models.Locations;
using aiio.Domain.Models.Processes;
using aiio.Domain.Models.Resources;
using aiio.Domain.Models.Roles;
using aiio.Framework.BaseModel;

namespace aiio.Domain.Models.Users
{
    public class User : BaseModel
    {
        public List<Process> Processes { get; private set; } = default!;
        public List<Department> Departments { get; private set; } = default!;
        public List<Role> Roles { get; private set; } = default!;
        public List<Resource> Resources { get; private set; } = default!;
        public List<Location> Locations { get; private set; } = default!;
    }
}