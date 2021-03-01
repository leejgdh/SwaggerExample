using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DHDashBoard.Controllers
{
    public class CoinoneController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}