﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POCAcademicSystemUI.Models.Contract
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }

        public int CourseId { get; set; }

        public int StudentId { get; set; }

        public byte? Grade { get; set; }

        public Course Course { get; set; }

        public Student Student { get; set; }
    }
}