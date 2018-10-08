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
        private int _pageSize = 10;

        public HomeController(IHomeworkBll homeworkBll)
        {
            _homeworkBll = homeworkBll;
        }

        public IActionResult Index([FromQuery]int pageIndex = 1)
        {
            var pList = _homeworkBll.GetAllHomeworks(pageIndex, _pageSize);
            pList.PageIndex = pageIndex;
            pList.PageSize = _pageSize;
            return View(pList);
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

        public IActionResult ErrorPage()
        {
            return View();
        }
    }
}
