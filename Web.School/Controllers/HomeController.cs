using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using Web.School.Models;

namespace Web.School.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            MultipleEntityResult<StudentModel> stdList = new MultipleEntityResult<StudentModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7007/api/Student/getStudentList?Page=1&Size=3&SearchValue=M"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    stdList = JsonConvert.DeserializeObject<MultipleEntityResult<StudentModel>>(apiResponse);
                }
            }
            return View(stdList.Result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}