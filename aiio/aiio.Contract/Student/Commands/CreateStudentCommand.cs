using aiio.Framework.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aiio.Contract.Student.Commands
{
    public class CreateStudentCommand : ICommand<Guid>
    {
        public string Name { get; set; } = default!;
        public int Age { get; set; }

        public CreateStudentCommand(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
