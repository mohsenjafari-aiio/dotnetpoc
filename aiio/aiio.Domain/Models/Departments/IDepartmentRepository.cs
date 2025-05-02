using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using aiio.Domain.Models.Students;

namespace aiio.Domain.Models.Departments
{
    public interface IDepartmentRepository
    {
        Task<Department?> GetByIdAsync(Guid id);
        Task AddAsync(Department student);
        Task DeleteAsync(Guid id);
    }
}