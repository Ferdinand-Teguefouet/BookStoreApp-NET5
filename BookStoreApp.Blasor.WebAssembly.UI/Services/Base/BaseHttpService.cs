using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BookStoreApp.Blazor.WebAssembly.UI.Services.Base
{
    public class BaseHttpService
    {
        private readonly IClient _client;
        private readonly ILocalStorageService _localStorageService;

        public BaseHttpService(IClient client, ILocalStorageService localStorageService)
        {
            this._client = client;
            this._localStorageService = localStorageService;
        }

        // Manage exceptions
        protected Response<Guid> ConvertApiExceptions<Guid>(ApiException apiException)
        {            
            if (apiException.StatusCode == 400)
            {
                return new Response<Guid>() { Message = "Validation errors have occurred.", ValidationErrors = apiException.Response, Success = false }; 
            }
            if (apiException.StatusCode == 404)
            {
                return new Response<Guid>() { Message = "The required item could not be found.", Success = false };
            }

            if (apiException.StatusCode == 401)
            {
                return new Response<Guid>() { Message = "Invalid Credentials, Please try again.", Success = false };
            }

            if (apiException.StatusCode >= 200 && apiException.StatusCode <= 299)
            {
                return new Response<Guid>() { Message = "Operation Reported Success.", Success = true };
            }

            return new Response<Guid>() { Message = "Something went wrong, please try again.", Success = false };
        }

        // Add the token
        protected async Task GetBearerToken()
        {
            //var token = await _localStorageService.GetItemAsStringAsync("accessToken"); //ça marche aussi
            var token = await _localStorageService.GetItemAsync<string>("accessToken"); // ça marche aussi
            if (token != null)
            {
                _client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            }
        }
    }
}
