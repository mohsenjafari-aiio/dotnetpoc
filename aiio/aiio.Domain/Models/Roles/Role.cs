using aiio.Domain.Models.Locations;
using aiio.Domain.Models.Processes;
using aiio.Domain.Models.Users;
using aiio.Framework.BaseModel;

namespace aiio.Domain.Models.Roles
{
    public class Role : BaseModel
    {
        public Guid CreatedById { get; private set; }
        public User CreatedBy { get; private set; } = default!;
        public List<Process> Processes { get; private set; } = default!;

        public static Role Create(Guid id, string title, User user)
        {
            var role = new Role
            {
                Id = id,
                Title = title,
                CreatedBy = user
            };

            return role;
        }
    }
}
