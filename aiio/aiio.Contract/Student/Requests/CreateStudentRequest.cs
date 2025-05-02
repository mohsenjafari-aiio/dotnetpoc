using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aiio.Contract.Student.Requests
{
    public class CreateStudentRequest
    {
        public string Name { get; set; } = default!;
        public int Age { get; set; }
    }
}
