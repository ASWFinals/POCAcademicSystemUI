using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using POCAcademicSystemUI.Models.Contract;

namespace POCAcademicSystemUI.Models
{
    public class EnrollmentDetails
    {
        public Course Course { get; set; }
        public Student Student { get; set; }
        public Enrollment Enrollment { get; set; }
    }
}