using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using Web.School.Models;
using X.PagedList.Mvc.Core;
using X.PagedList;
using X.PagedList.Web.Common;
using X.PagedList.Web;
using X.PagedList.Mvc;
namespace Web.School.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index(int? Page, int? size,string? SearchValue="")
        {
            MultipleEntityResult<StudentModel> stdList = new MultipleEntityResult<StudentModel>();
            using (var httpClient = new HttpClient())
            {
                //Page = Page ?? 1;
                //size = size ?? 3;
                using (var response = await httpClient.GetAsync("https://localhost:7007/api/Student/getStudentList?Page="+ Page + "&Size="+ size + "&SearchValue="+ SearchValue+""))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    stdList = JsonConvert.DeserializeObject<MultipleEntityResult<StudentModel>>(apiResponse);
                }
            }

            

            return View(stdList.Result.ToList().ToPagedList(Page ?? 1, 3));
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