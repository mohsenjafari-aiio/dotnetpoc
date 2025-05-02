namespace aiio.Domain.Models.Processes
{
    public interface IProcessRepository
    {
        Task<Process> Add(Process process);
        Task<IList<Process>> GetAllProcessesAsync();
        Task<Process> GetProcessDetailAsync(Guid processId);
    }
}