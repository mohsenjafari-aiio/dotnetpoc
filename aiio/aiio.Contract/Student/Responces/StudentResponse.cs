using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aiio.Contract.Student.Responces
{
    public class StudentResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public int Age { get; set; }
        public List<int> Scores { get; set; } = new();
    }
}
