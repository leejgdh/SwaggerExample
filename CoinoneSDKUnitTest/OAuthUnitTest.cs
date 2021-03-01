using System;
using System.Net.Http;
using System.Threading.Tasks;
using CoinoneSDK.Clients;
using CoinoneSDK.Models.OAuth;
using NUnit.Framework;

namespace CoinoneSDKUnitTest
{
    public class OAuthUnitTest
    {
        [SetUp]
        public void Setup()
        {
        }


        [TestCase("")]
        public async Task GetRequestToken(string app_id)
        {
            using (HttpClient http_client = new HttpClient())
            {
                CoinoneClient client = new CoinoneClient(http_client);

                var response = await client.SendRequest<object>(new GetRequestToken(app_id));

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
