using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Campus.BllInterface;
using Campus.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Campus.Controllers
{
    public class AnswerController : Controller
    {
        private readonly IAnswerBll _answerBll;

        public AnswerController(IAnswerBll answerbll)
        {
            _answerBll = answerbll;
        }

        [HttpGet]
        public IActionResult Insert([FromQuery] int homeworkId)
        {
            ViewData["homeworkId"] = homeworkId;
            return View();
        }

        [HttpPost]
        public IActionResult Insert(Answer answer)
        {
            var UserId = User.Claims.FirstOrDefault(x => x.Type == "UserId");
            answer.AuthorId = int.Parse(UserId.Value);
            bool ok = _answerBll.Insert(answer);
            if (ok)
            {
                return Redirect("/Homework/ShowDetailForStudent?homeworkId=" + answer.HomeworkId);
            }
            else
            {
                return Redirect("/Home/ErrorPage");
            }
        }

        [HttpGet]
        public IActionResult Update([FromQuery] int answerId)
        {
            Answer answer = _answerBll.GetDetail(answerId);
            return View(answer);
        }

        [HttpPost]
        public IActionResult Update(Answer answer)
        {
            bool ok = _answerBll.Update(answer);
            return Json(new { isSucceed = ok });
        }

        public IActionResult Delete([FromQuery] int answerId)
        {
            Answer answer = _answerBll.GetDetail(answerId);
            bool ok = _answerBll.Delete(answerId);
            if (ok)
            {
                return Redirect("/Homework/ShowDetailForStudent?homeworkId=" + answer.HomeworkId);
            }
            else
            {
                return Redirect("/Home/ErrorPage");
            }
        }
    }
}