using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Instructors.WebApi.Data.Models.Entity;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace Instructors.WebApi.Data.Models
{
    [Table("Instructors")]
    public class Instructor : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
