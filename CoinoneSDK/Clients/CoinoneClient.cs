
using System;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CoinoneSDK.Interfaces;
using CoinoneSDK.Models.Base;
using DHSDK.Helpers;
using Newtonsoft.Json;

namespace CoinoneSDK.Clients
{

    public class CoinoneClient
    {
        private const string PRODUCTIONURL = "https://api.coinone.co.kr";

        private HttpClient _client;

        private string _secretKey;

        public CoinoneClient(HttpClient client)
        {
            _client = client;
        }

        public CoinoneClient(HttpClient client, string secret_key)
        {
            _client = client;
            _secretKey = secret_key;
        }

        public async Task<ResponseBase<TResponse>> SendRequest<TResponse>(IRequestBase request)
        {
            _client.BaseAddress = new Uri(PRODUCTIONURL);

            HttpRequestMessage request_message = new HttpRequestMessage(request.HttpMethod, request.EndPoint);

            if (request.HttpMethod == HttpMethod.Post || request.HttpMethod == HttpMethod.Put || request.HttpMethod == HttpMethod.Delete || request.HttpMethod == HttpMethod.Patch)
            {
                request_message.Content = new StringContent(request.ToPayload(), Encoding.UTF8, "application/json");

            }
            else if (request.HttpMethod == HttpMethod.Get)
            {

                var properties = request.GetType().GetProperties();

                string query_string = "?";

                foreach (var property in properties)
                {
                    //해당 프로퍼티에 JsonIgnore 들어있으면 건너뜀

                    bool is_ignore = Attribute.IsDefined(property, typeof(JsonIgnoreAttribute));

                    if (is_ignore)
                    {
                        continue;
                    }

                    bool has_jsonproperty = Attribute.IsDefined(property, typeof(JsonPropertyAttribute));

                    if (has_jsonproperty)
                    {
                        var json_property = property.GetCustomAttribute<JsonPropertyAttribute>(false);

                        query_string += $"{json_property.PropertyName}={property.GetValue(request)}&";
                    }
                    else if (!string.IsNullOrEmpty(property.GetValue(request).ToString()))
                    {
                        query_string += $"{property.Name}={property.GetValue(request)}&";
                    }

                }

                request_message = new HttpRequestMessage(request.HttpMethod, request.EndPoint + query_string);
            }

            var response = await _client.SendAsync(request_message);

            string content = await response.Content.ReadAsStringAsync();
            
            ResponseBase<TResponse> result = new ResponseBase<TResponse>()
            {
                IsSuccess = response.IsSuccessStatusCode
            };

            if (response.IsSuccessStatusCode)
            {
                result.Result = JsonConvert.DeserializeObject<TResponse>(content);
            }
            else
            {
                result.Message = content;
            }


            return result;
        }



        public async Task<ResponseBase<TResponse>> SendRequest<TResponse>(CoinonePrivateRequestBase request) where TResponse : CoinoneResponseBase
        {
            _client.BaseAddress = new Uri(PRODUCTIONURL);

            //header

            //X-COINONE-PAYLOAD
            //X-COINONE-SIGNATURE

            string payload = request.ToPayload();

            _client.DefaultRequestHeaders.Add("X-COINONE-PAYLOAD", payload);

            string signature = CryptoHelper.SHA512_ComputeHash(payload, _secretKey);

            _client.DefaultRequestHeaders.Add("X-COINONE-SIGNATURE", signature);


            HttpRequestMessage request_message = new HttpRequestMessage(request.HttpMethod, request.EndPoint);


            var response = await _client.SendAsync(request_message);

            string content = await response.Content.ReadAsStringAsync();

            ResponseBase<TResponse> result = new ResponseBase<TResponse>()
            {
                IsSuccess = response.IsSuccessStatusCode
            };

            if (response.IsSuccessStatusCode)
            {
                result.Result = JsonConvert.DeserializeObject<TResponse>(content);
            }
            else
            {
                result.Message = content;
            }


            return result;
        }




    }
}