using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cookbook.WebApplication.Controllers
{

    [Authorize]
    public class PreparedRecipeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}