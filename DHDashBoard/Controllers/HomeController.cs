using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DHDashBoard.Models;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using DHDashBoard.Models.ViewModels;
using DHDashBoardSDK.Clients;
using DHDashBoardSDK.Models.Enums;
using DHDashBoardSDK.Models.DTO.ShoppingLists;

namespace DHDashBoard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {

            var client = new ShoppingListClient(new HttpClient(), EApiMode.SANDBOX);

            var res = await client.SendRequest<List<ResponseShops>>(new RequestShops());

            if (res.IsSuccess)
            {
                IndexViewModel vm = new IndexViewModel();
                vm.Shops = res.Result;

                return View(vm);
            }
            else
            {
                return Error();
            }

            
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
    }
}
