using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Campus.Models;
using Microsoft.AspNetCore.Authorization;
using Campus.BllInterface;
using Campus.Domain;

namespace Campus.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IHomeworkBll _homeworkBll;

        public HomeController(IHomeworkBll homeworkBll)
        {
            _homeworkBll = homeworkBll;
        }

        public IActionResult Index()
        {
            var pageIndex = 1;
            var pageSize = 10;
            var list = _homeworkBll.GetAllHomeworks(pageIndex,pageSize);
            ViewData["List"] = list;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
