using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Instructors.WebApi.AutoMapper;
using Instructors.WebApi.Data.Models;
using Instructors.WebApi.Data.Repository.Interfaces;
using Instructors.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Extensions;

namespace Instructors.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        public IInstructorRepository InstructorRepository { get; set; }
        public ICommonMapper Mapper { get; }

        public InstructorsController(IInstructorRepository instructorRepository, ICommonMapper mapper)
        {
            InstructorRepository = instructorRepository;
            Mapper = mapper;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(InstructorRepository.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(InstructorRepository.Get(id));
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]InstructorDto instructor)
        {
            InstructorRepository.Save(Mapper.Map<Instructor>(instructor));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]InstructorDto instructor)
        {
            Instructor dbInstructor = InstructorRepository.Get(id);

            if (instructor == null)
            {
                return NotFound();
            }

            dbInstructor.FirstName = instructor.FirstName;
            dbInstructor.MiddleName = instructor.MiddleName;
            dbInstructor.LastName = instructor.LastName;

            InstructorRepository.Update(dbInstructor);
            return Ok(dbInstructor);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Instructor instructor = InstructorRepository.Get(id);
            if (instructor == null)
            {
                return NotFound();
            }
            InstructorRepository.Delete(instructor);
            return Ok(instructor);
        }
    }
}
