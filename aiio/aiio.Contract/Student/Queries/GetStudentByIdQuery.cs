using aiio.Contract.Student.Responces;
using aiio.Framework.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aiio.Contract.Student.Queries
{
    public class GetStudentByIdQuery : IQuery<StudentResponse>
    {
        public Guid Id { get; set; }

        public GetStudentByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
