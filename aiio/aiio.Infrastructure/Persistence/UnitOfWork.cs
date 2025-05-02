using aiio.Domain.Interfaces;

namespace aiio.Infrastructure.Persistence
{   
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AiioDbContext _context;

        public UnitOfWork(AiioDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
