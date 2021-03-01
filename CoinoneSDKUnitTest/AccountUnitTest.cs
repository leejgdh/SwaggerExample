using System;
using System.Net.Http;
using System.Threading.Tasks;
using CoinoneSDK.Clients;
using CoinoneSDK.Models.Account;
using NUnit.Framework;

namespace CoinoneSDKUnitTest
{
    public class AccountUnitTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("37a32d11-7aac-4bba-99cf-d12af2b9e2e1", "a0e3580f-371b-4df2-9b05-7f4f8117bbb9")]
        public async Task GetBalance(string SecretKey, string AccessToken)
        {
            using (HttpClient http_client = new HttpClient())
            {
                CoinoneClient client = new CoinoneClient(http_client,SecretKey);

                var response = await client.SendRequest<ResponseBalance>(new RequestBalance(AccessToken));

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
