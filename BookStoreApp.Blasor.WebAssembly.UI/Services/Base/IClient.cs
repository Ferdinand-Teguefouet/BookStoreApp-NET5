using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BookStoreApp.Blazor.WebAssembly.UI.Services.Base
{
    partial interface IClient
    {
        public HttpClient HttpClient { get; }
    }
}
