using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POCAcademicSystemUI.Models.Contract
{
    public class Course
    {
        public Course()
        {
            Enrollments = new List<Enrollment>();
        }

        public int CourseId { get; set; }

        public string Title { get; set; }

        public byte Credits { get; set; }

        public string InstructorName { get; set; }
               

        public IEnumerable<Enrollment> Enrollments { get; set; }
    }
}