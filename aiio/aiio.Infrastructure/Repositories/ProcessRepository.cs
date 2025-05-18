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

        public async Task<Process?> FindById(int processId)
        {
            return await _aiioDbContext.Processes.FirstOrDefaultAsync(r => r.Id == processId);
        }

        public async Task<IList<Process>> GetAllProcessesAsync()
        {
            return await _aiioDbContext.Processes.ToListAsync();
        }

        public async Task<Process?> GetProcessDetailAsync(int processId)
        {
            return await _aiioDbContext.Processes
                .Include(r => r.Resources)
                .Include(r => r.Locations)
                .Include(r => r.Departments)
                .Include(r => r.Roles)
                .Include(r => r.CreatedBy)
                .FirstOrDefaultAsync(r => r.Id == processId);
        }
    }
}
