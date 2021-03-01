using System.Net.Http;
using System.Threading.Tasks;
using CoinoneSDK.Clients;
using CoinoneSDK.Models.Enums;
using CoinoneSDK.Models.Public;
using NUnit.Framework;

namespace CoinoneSDKUnitTest
{
    public class PublicUnitTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("BTC")]
        [TestCase("POD")]
        public async Task OrderBook(ECurrency currency)
        {
            using (HttpClient http_client = new HttpClient())
            {
                CoinoneClient client = new CoinoneClient(http_client);

                var response = await client.SendRequest<ResponseOrderBook>(new RequestOrderBook(currency));

                if (response.IsSuccess)
                {
                    Assert.Pass();
                }
                else
                {
                    Assert.Fail(response.Message);
                }

            }

            Assert.Pass();
        }

        [TestCase("BTC")]
        [TestCase("POD")]
        public async Task Ticker(ECurrency currency)
        {
            using (HttpClient http_client = new HttpClient())
            {
                CoinoneClient client = new CoinoneClient(http_client);

                var response = await client.SendRequest<ResponseTicker>(new RequestTicker(currency));

                if (response.IsSuccess)
                {
                    Assert.Pass();
                }
                else
                {
                    Assert.Fail(response.Message);
                }

            }
        }

        [TestCase("BTC")]
        [TestCase("POD")]
        public async Task RecentCompleteOrder(ECurrency currency)
        {

            using (HttpClient http_client = new HttpClient())
            {
                CoinoneClient client = new CoinoneClient(http_client);

                var response = await client.SendRequest<ResponseRecentCompleteOrders>(new RequestRecentCompleteOrders(currency));

                if (response.IsSuccess)
                {
                    Assert.Pass();
                }
                else
                {
                    Assert.Fail(response.Message);
                }

            }
        }
    }
}