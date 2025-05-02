namespace aiio.Domain.Models.Students.Exceptions
{
    public class StudentDomainException : Exception
    {
        public StudentDomainException(string message) : base(message) { }
    }
}
