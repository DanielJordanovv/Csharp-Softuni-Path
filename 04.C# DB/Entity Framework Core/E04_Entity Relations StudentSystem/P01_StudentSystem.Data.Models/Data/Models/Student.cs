using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P01_StudentSystem.Data.Models
{
    public class Student
    {
        public Student()
        {
            this.Homeworks = new HashSet<Homework>();
            this.StudentsCourses = new HashSet<StudentCourse>();
        }
        [Key]
        public int StudentId { get; set; }

        [MaxLength(100)]
        [Unicode(true)]
        public string Name { get; set; } = null!;
        [StringLength(10, MinimumLength = 10)]
        [Unicode(false)]
        [Required]
        public string PhoneNumber { get; set; } 
        public DateTime RegisteredOn { get; set; }
        public DateTime? Birthday { get; set; }
        public ICollection<Homework> Homeworks { get; set; }
        public ICollection<StudentCourse> StudentsCourses { get; set; }
    }
}
