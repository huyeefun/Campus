using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Campus.Controllers
{
    public class UploadController : Controller
    {
        const string PATH = @"/Upload/Images/";
        private readonly IHostingEnvironment _environment;
        private readonly ILogger<UploadController> _logger;

        public UploadController(IHostingEnvironment environment, ILogger<UploadController> logger)
        {
            _environment = environment;
            _logger = logger;
        }

        [Authorize]
        public IActionResult Create()
        {
            //1. 读取图片
            var files = Request.Form.Files;
            var fileName = Guid.NewGuid().ToString();
            foreach (var file in files)
            {
                fileName += file.FileName;
                // 验证 是不是图片
                //2. 保存到本地文件系统
                var directory = $"{_environment.WebRootPath}{PATH}";
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                using (var fs = new FileStream($"{directory}{fileName}", FileMode.Create))
                {
                    file.CopyTo(fs);
                }
            }
            //3. 返回地址
            return Json(new { location = $"{PATH}{fileName}" });
        }
    }
}