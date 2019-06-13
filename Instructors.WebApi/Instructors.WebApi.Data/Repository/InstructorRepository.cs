using System;
using System.Collections.Generic;
using System.Text;
using Instructors.WebApi.Data.Models;
using Instructors.WebApi.Data.Repository.Interfaces;

namespace Instructors.WebApi.Data.Repository
{
    public class InstructorRepository : Repository<Instructor>, IInstructorRepository
    {
        public InstructorRepository(DatabaseContext databaseContext) : base(databaseContext) { }
    }
}
