using HVK_ZZTop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HVK_ZZTop.Controllers {
    public class ErorrController : Controller {
        public IActionResult Index() {
            return Error(500);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [HttpGet("/error")]
        public IActionResult Error(int? statusCode = 500) {
            if (statusCode.HasValue) {
                if (statusCode.Value == 404 || statusCode.Value == 500) {
                    var viewName = statusCode.ToString();
                    return View(viewName);
                }
            }
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
