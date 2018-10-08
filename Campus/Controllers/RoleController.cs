using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campus.BllInterface;
using Microsoft.AspNetCore.Mvc;

namespace Campus.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleBll _roleBll;

        public RoleController(IRoleBll roleBll)
        {
            _roleBll = roleBll;
        }
    }
}