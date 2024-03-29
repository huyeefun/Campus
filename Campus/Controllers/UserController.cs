﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Campus.Bll;
using Campus.BllInterface;
using Campus.Dal;
using Campus.DalInterface;
using Campus.Domain;
using Campus.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Campus.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserBll _userBll;
        public UserController(IUserBll userBll)
        {
            _userBll = userBll;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterInputModel registerInput)
        {
            try
            {
                bool ok = _userBll.InsertUser(new User { UserName = registerInput.UserName, Password = registerInput.Password }, registerInput.IsTeacher);
                JsonResult jsonResult = Json(new { isSucceed = ok });
                return jsonResult;
            }
            catch (ValidationException ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            var loginUser = new User();
            loginUser.UserName = loginModel.UserName;
            loginUser.Password = loginModel.Password;
            bool result = _userBll.ValidLogin(loginUser);
            if (result)
            {
                loginUser.RoleId = _userBll.GetRoleIdFormUName(loginUser.UserName);
                loginUser.Id = _userBll.GetIdByUName(loginUser.UserName);
                var claim = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,loginModel.UserName),
                    new Claim(ClaimTypes.Role,loginUser.RoleId.ToString()),
                    new Claim("UserId",loginUser.Id.ToString()),
                };
                var claimIdentity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity));
                return Redirect("/Home/Index");
            }
            else
            {
                ViewData["error"] = "登录失败！用户名或者密码错误！";
                return View();
            }
        }

        public IActionResult SignOut()
        {
            HttpContext.SignOutAsync();
            return Redirect("/Home/Index");
        }

        [HttpGet]
        public IActionResult ExistUserName([FromQuery]string userName)
        {
            bool ok = _userBll.ExistUserName(userName);
            return Json(new { result = ok });
        }
    }
}