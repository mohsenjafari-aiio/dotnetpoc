namespace aiio.Domain.Models.Students
{
    public interface IStudentRepository
    {
        Task<Student?> GetByIdAsync(Guid id);
        Task AddAsync(Student student);
        Task DeleteAsync(Guid id);
    }
}