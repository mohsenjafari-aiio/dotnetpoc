using aiio.Domain.Models.Students.Exceptions;

namespace aiio.Domain.Models.Students
{
    public class Student
    {
        private readonly List<int> _scores = new();

        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; }
        public int Age { get; private set; }

        public IReadOnlyCollection<int> Scores => _scores.AsReadOnly();

        public static Student Create(string name, int age)
        {
            var student = new Student();
            student.ChangeName(name);
            student.Age = age;
            return student;
        }

        // Domain Behavior: Change Name
        public void ChangeName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new StudentDomainException("Name cannot be empty.");

            Name = newName;
        }

        // Domain Behavior: Add Score
        public void AddScore(int score)
        {
            if (score < 0 || score > 100)
                throw new StudentDomainException("Score must be between 0 and 100.");

            _scores.Add(score);
        }

        // Domain Behavior: Calculate Average
        public double GetAverageScore()
        {
            if (!_scores.Any()) return 0;
            return _scores.Average();
        }
    }
}
