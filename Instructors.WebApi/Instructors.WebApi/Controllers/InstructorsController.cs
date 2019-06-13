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
        /// <summary>
        /// Provide access to instructors in database
        /// </summary>
        public IInstructorRepository InstructorRepository { get; set; }
        /// <summary>
        /// Provide access to object mapper
        /// </summary>
        public ICommonMapper Mapper { get; }

        public InstructorsController(IInstructorRepository instructorRepository, ICommonMapper mapper)
        {
            InstructorRepository = instructorRepository;
            Mapper = mapper;
        }

        /// <summary>
        /// Action that only support the HTTP GET method wich return all instructors. 
        /// </summary>
        /// <returns>Return JSON array with StatucCode 200</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(InstructorRepository.GetAll());
        }

        /// <summary>
        /// Action that only support the HTTP GET method which return instructor by id. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>400 Bad Request if instructor by id doesn`t exist or 201 Created if success</returns>
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

        /// <summary>
        /// Action that only support the HTTP POST method, which create a new instructor. 
        /// </summary>
        /// <param name="instructor">New instructor</param>
        /// <returns>400 Bad Request if argument is null or 201 Created if success</returns>
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

        /// <summary>
        /// Action that only support the HTTP PUT method, which update instructor. 
        /// </summary>
        /// <param name="id">Instructor ID to be updated</param>
        /// <param name="instructor">Instructor to update</param>
        /// <returns>400 Bad Request if instructor by id doesn`t exist or 204 No Content if success</returns>
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

        /// <summary>
        /// Action that only support the HTTP PUT method, which update instructor. 
        /// </summary>
        /// <param name="id">Instructor ID to be deleted</param>
        /// <returns>400 Bad Request if instructor by id doesn`t exist or 204 No Content if success</returns>
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
