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
        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(InstructorRepository.GetAll());
        }
        
        [HttpGet("{id}", Name = "GetInstructor")]
        public async Task<IActionResult> Get(int id)
        {
            Instructor dbInstructor = await InstructorRepository.GetAsync(id);

            if (dbInstructor == null)
            {
                return BadRequest();
            }

            return Ok(dbInstructor);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]InstructorDto instructor)
        {
            if (instructor == null)
            {
                return BadRequest();
            }

            Instructor instructorToSave = Mapper.Map<Instructor>(instructor);
            if (!await InstructorRepository.SaveAsync(instructorToSave))
            {
                throw new Exception("Creating a instructor failed on save.");
            }

            InstructorDto instructorToReturn = Mapper.Map<InstructorDto>(instructorToSave);
            return CreatedAtRoute("GetInstructor", new { id = instructorToReturn.Id }, instructorToReturn);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody]InstructorDto instructor)
        {
            Instructor dbInstructor = await InstructorRepository.GetAsync(id);

            if (instructor == null)
            {
                return BadRequest();
            }

            Mapper.Map(instructor, dbInstructor);

            if (!InstructorRepository.Update(dbInstructor))
            {
                throw new Exception($"Updating a instructor {id} failed on save.");
            }

            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Instructor instructor = await InstructorRepository.GetAsync(id);
            if (instructor == null)
            {
                return NotFound();
            }
            
            if (!InstructorRepository.Delete(instructor))
            {
                throw new Exception($"Deleting a instructor {id} failed on save.");
            }
            return NoContent();
        }
    }
}
