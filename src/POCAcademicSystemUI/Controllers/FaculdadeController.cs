using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using POCAcademicSystemUI.Models.Contract;
using POCAcademicSystemUI.Providers;

namespace POCAcademicSystemUI.Controllers
{
    public class FaculdadeController : Controller
    {
        private readonly HttpRequesterProvider _httpClient;

        public FaculdadeController()
        {
            _httpClient = new HttpRequesterProvider("http://apipocacademic-staging.azurewebsites.net/api", "application/json");
        }

        // GET: Faculdade
        public async Task<ActionResult> Index()
        {
            var response = _httpClient.Request("/enrollment", HttpMethod.Get);

            //TODO: Try to deserialize object

            //List<Enrollment> enrollments = await response.Result.Content.ReadAsAsync<List<Enrollment>>();

            return View();
        }
    }
}