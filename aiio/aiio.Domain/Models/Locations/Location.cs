using aiio.Domain.Models.Processes;
using aiio.Domain.Models.Users;
using aiio.Framework.BaseModel;

namespace aiio.Domain.Models.Locations
{
    public class Location : BaseModel
    {
        public Guid CreatedById { get; private set; }
        public User CreatedBy { get; private set; } = default!;
        public List<Process> Processes { get; private set; } = default!;

        public static Location Create(Guid id, string title, User user)
        {
            var location = new Location
            {
                Id = id,
                Title = title,
                CreatedBy = user                
            };

            return location;
        }
    }
}
