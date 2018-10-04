using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Campus.BllInterface;
using Campus.Domain;
using Campus.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Campus.Controllers
{
    public class HomeworkController : Controller
    {
        private readonly IHomeworkBll _homeworkBll;
        private readonly IUserBll _userBll;

        public HomeworkController(IHomeworkBll homeworkBll, IUserBll userBll)
        {
            _homeworkBll = homeworkBll;
            _userBll = userBll;
        }

        [HttpGet]
        [Authorize(Roles = "2")]
        public IActionResult PublishedHomework()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PublishedHomework(HomeworkInputModel inputContent)
        {
            if (ModelState.IsValid)
            {
                Homework homework = new Homework();
                homework.Title = inputContent.Title;
                homework.Content = inputContent.Content;
                homework.ReleaseTime = DateTime.Now;
                homework.AuthorId = _userBll.GetIdByUName(User.Identity.Name);
                bool isOk = _homeworkBll.Insert(homework);
                return Redirect("/Home/Index");
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("提醒:");
                foreach (var item in ModelState.Values)
                {
                    foreach (var error in item.Errors)
                    {
                        sb.AppendLine(error.ErrorMessage);
                    }
                }
                ViewData["error"] = sb.ToString();
                return View();
            }
        }

        public IActionResult ErrorHints()
        {
            return View();
        }

        public IActionResult ShowDetailForTeahcher([FromQuery] int homeworkId)
        {
            Homework homework = _homeworkBll.GetDetail(homeworkId);
            return View(homework);
        }

        public IActionResult ShowDetailForStudent([FromQuery]int homeworkId)
        {
            Homework homework = _homeworkBll.GetDetail(homeworkId);
            return View(homework);
        }
        [HttpGet]
        public IActionResult Update([FromQuery] int homeworkId)
        {
            Homework homework = _homeworkBll.GetDetail(homeworkId);
            return View(homework);
        }
        [HttpPost]
        public IActionResult Update(Homework homework)
        {
            bool ok = _homeworkBll.Update(homework);
            return Json(new { isSucceed = ok });
        }

        public IActionResult Delete([FromQuery]int homeworkId)
        {
            Homework homework = _homeworkBll.GetDetail(homeworkId);
            homework.Deleted = true;
            bool ok = _homeworkBll.Delete(homework);
            if (ok)
            {
                return Redirect("/Home/Index");
            }
            else
            {
                return Redirect("/Home/ErrorPage");
            }
        }
    }
}