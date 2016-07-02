using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POCAcademicSystemUI.Models.Contract
{
    public class Student
    {
        public Student()
        {
            Enrollments = new List<Enrollment>();
        }

        public int StudentId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string ContactNumber { get; set; }

        public DateTime? EnrollmentDate { get; set; }

        public IEnumerable<Enrollment> Enrollments { get; set; }

    }
}