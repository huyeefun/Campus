using System;
using System.Collections.Generic;
using System.Linq;
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

        public HomeworkController(IHomeworkBll homeworkBll,IUserBll userBll)
        {
            _homeworkBll = homeworkBll;
            _userBll = userBll;
        }

        [HttpGet]
        [Authorize(Roles ="2")]
        public IActionResult PublishedHomework()
        {
            var a = User.Identities;
            return View();
        }

        [HttpPost]
        public IActionResult PublishedHomework(HomeworkInputModel inputContent)
        {
            Homework homework = new Homework();
            homework.Title = inputContent.Title;
            homework.Content = inputContent.Content;
            homework.ReleaseTime = DateTime.Now;
            homework.AuthorId =_userBll.GetIdByUName(User.Identity.Name) ;
            bool isOk= _homeworkBll.Insert(homework);
            return View();
        }
        public IActionResult ErrorHints()
        {
            return View();
        }
    }
}