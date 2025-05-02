using aiio.Contract.Student.Commands;
using aiio.Domain.Interfaces;
using aiio.Domain.Models.Processes;
using aiio.Domain.Models.Students;
using aiio.Framework.Abstractions;

namespace aiio.Application.StudentHandlers
{
    public class CreateStudentCommandHandler : ICommandHandler<CreateStudentCommand, Guid>
    {
        private readonly IProcessRepository _studentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateStudentCommandHandler(IProcessRepository studentRepository, IUnitOfWork unitOfWork)
        {
            _studentRepository = studentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = Student.Create(request.Name, request.Age); 
            //await _studentRepository.AddAsync(student);
            await _unitOfWork.SaveChangesAsync(); 
            return student.Id;
        }
    }
}
