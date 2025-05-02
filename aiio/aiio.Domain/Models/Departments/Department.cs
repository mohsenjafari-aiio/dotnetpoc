using aiio.Domain.Models.Processes;
using aiio.Domain.Models.Users;
using aiio.Framework.BaseModel;

namespace aiio.Domain.Models.Departments
{
    public class Department : BaseModel
    {
        public Guid CreatedById { get; private set; }
        public User CreatedBy { get; private set; } = default!;
        public List<Process> Processes { get; private set; } = default!;
    }
}
