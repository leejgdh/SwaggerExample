using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DHDashBoardSDK.Interfaces;
using DHDashBoardSDK.Models.Base;
using DHDashBoardSDK.Models.Enums;
using Newtonsoft.Json;

namespace DHDashBoardSDK.Clients
{
    public class ShoppingListClient
    {
        private const string SANDBOXURL = "https://localhost:5001";
        private const string PRODUCTIONURL = "https://DHDashBoardApi.azurewebsites.net";

        private HttpClient _client;
        private EApiMode _mode;

        public ShoppingListClient(HttpClient client, EApiMode mode = EApiMode.SANDBOX){
            _client = client;
            _mode = mode;
        }


        public async Task<ApiResponseBase<TResponse>> SendRequest<TResponse>(IRequestBase request)
        {

            if(_mode == EApiMode.SANDBOX)
            {
                _client.BaseAddress = new Uri(SANDBOXURL);

            }else if(_mode == EApiMode.PRODUCTION)
            {
                _client.BaseAddress = new Uri(PRODUCTIONURL);
            }

            HttpRequestMessage request_message = new HttpRequestMessage(request.HttpMethod, request.EndPoint);

            if(request.HttpMethod == HttpMethod.Post || request.HttpMethod == HttpMethod.Put || request.HttpMethod == HttpMethod.Delete || request.HttpMethod == HttpMethod.Patch)
            {
                request_message.Content = new StringContent(request.ToPayload(), Encoding.UTF8, "application/json");

            }else if(request.HttpMethod == HttpMethod.Get)
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

                    if (!string.IsNullOrEmpty(property.GetValue(request).ToString()))
                    {
                        query_string += $"{property.Name}={property.GetValue(request)}&";
                    }

                }

                request_message = new HttpRequestMessage(request.HttpMethod, request.EndPoint+query_string);
            }

            var response = await _client.SendAsync(request_message);

            string content = await response.Content.ReadAsStringAsync();

            ApiResponseBase<TResponse> result = new ApiResponseBase<TResponse>()
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
