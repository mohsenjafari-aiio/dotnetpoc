using aiio.Contract.Student.Commands;
using FluentValidation;

namespace aiio.Application.StudentHandlers
{
    public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
    {
        public CreateStudentCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name must be less than 100 characters.");

            RuleFor(x => x.Age)
                .InclusiveBetween(5, 100).WithMessage("Age must be between 5 and 100.");
        }
    }   
}
