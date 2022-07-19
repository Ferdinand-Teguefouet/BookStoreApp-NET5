using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BookStoreApp.Blazor.Server.UI.Services.Base
{
    partial interface IClient
    {
        public HttpClient HttpClient { get; }
    }
}
