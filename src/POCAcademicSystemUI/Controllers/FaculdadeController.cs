using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using POCAcademicSystemUI.Models;
using POCAcademicSystemUI.Models.Contract;
using POCAcademicSystemUI.Providers;

namespace POCAcademicSystemUI.Controllers
{
    public class FaculdadeController : Controller
    {
        private readonly HttpRequesterProvider _httpClient;

        public FaculdadeController()
        {
            _httpClient = new HttpRequesterProvider("http://apipocacademic.azurewebsites.net/api", "application/json");
        }

        // GET: Faculdade
        public ActionResult Index()
        {
            //var result = _httpClient.Request("/enrollment/1", HttpMethod.Get);
            //using (var client = _httpClient)
            //{
            //    var result = client.Request("/enrollment/1", HttpMethod.Get);
            //    var content = result.Content.ReadAsAsync<Enrollment>().Result;
            //}
                


            //using (var client = _httpClient)
            //{
            //    var result =  client.Request("/student",HttpMethod.Get);
            //    var content =  result.Content.ReadAsAsync<List<Student>>().Result;
            //}
            return View();
        }

        public ActionResult ListGrades()
        {
            var enrollments = new List<Enrollment>();
            var students = new List<Student>();
            var courses = new List<Course>();
            var enrollmentDetails = new List<EnrollmentDetails>();

                        
            using (var client = _httpClient)
            {
                var result = client.Request("/enrollment", HttpMethod.Get);
                enrollments = result.Content.ReadAsAsync<List<Enrollment>>().Result;
            }



            using (var client = _httpClient)
            {
                var result = client.Request("/student", HttpMethod.Get);
                students = result.Content.ReadAsAsync<List<Student>>().Result;
            }

            using (var client = _httpClient)
            {
                var result = client.Request("/course", HttpMethod.Get);
                courses = result.Content.ReadAsAsync<List<Course>>().Result;

                //return View(content);
            }

            foreach (var enrollment in enrollments)
            {
                enrollmentDetails.Add(new EnrollmentDetails() { 
                    Course = courses.FirstOrDefault(c => c.CourseId == enrollment.CourseId),
                    Student = students.FirstOrDefault(s => s.StudentId == enrollment.StudentId),
                    Enrollment = enrollment                    
                });
            }

            return View(enrollmentDetails);
        }

        public ActionResult ListCourses()
        {
            using (var client = _httpClient)
            {
                var result = client.Request("/course", HttpMethod.Get);
                var content = result.Content.ReadAsAsync<List<Course>>().Result;

                return View(content);
            }

            return View();
        }
    }
}