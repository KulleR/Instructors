using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Instructors.WebApi.Models
{
    public class InstructorDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }
}
