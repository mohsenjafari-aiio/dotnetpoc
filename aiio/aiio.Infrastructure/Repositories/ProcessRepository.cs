using aiio.Domain.Models.Processes;
using aiio.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace aiio.Infrastructure.Repositories
{
    public class ProcessRepository : IProcessRepository
    {
        public readonly AiioDbContext _aiioDbContext;        

        public ProcessRepository(AiioDbContext aiioDbContext)
        {
            _aiioDbContext = aiioDbContext;
        }

        public async Task<Process> Add(Process process)
        {
            await _aiioDbContext.Processes.AddAsync(process);
            return process;
        }

        public async Task<IList<Process>> GetAllProcessesAsync()
        {
            return await _aiioDbContext.Processes.ToListAsync();
        }

        public async Task<Process> GetProcessDetailAsync(Guid processId)
        {
            return await _aiioDbContext.Processes
                .Include(r => r.Resources)
                .Include(r => r.Locations)
                .Include(r => r.Departments)
                .Include(r => r.Roles)
                .Include(r => r.CreatedBy)
                .SingleAsync(r => r.Id == processId);
        }
    }
}
