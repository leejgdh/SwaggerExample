using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CoinoneSDK.Clients;
using CoinoneSDK.Models.Enums;
using CoinoneSDK.Models.Public;
using Microsoft.AspNetCore.Mvc;

namespace DHDashBoard.Controllers
{
    public class CoinoneController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        
        public CoinoneController(
            IHttpClientFactory clientFactory
        )
        {
            _clientFactory = clientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderBook(){

            CoinoneClient client = new CoinoneClient(_clientFactory.CreateClient("Coinone"));

            var res = await client.SendRequest<ResponseOrderBook>(new RequestOrderBook(ECurrency.POD));

            if(res.IsSuccess){
                return Ok(res);
            }else{
                return BadRequest(res.Message);
            }
        }

         [HttpGet]
        public async Task<IActionResult> GetTick(){

            CoinoneClient client = new CoinoneClient(_clientFactory.CreateClient("Coinone"));

            var res = await client.SendRequest<ResponseTicker>(new RequestTicker(ECurrency.POD));

            if(res.IsSuccess){
                return Ok(res);
            }else{
                return BadRequest(res.Message);
            }
        }
    }
}