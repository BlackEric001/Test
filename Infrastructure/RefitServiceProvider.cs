using Refit;
using System;
using System.Net.Http;

namespace Infrastructure
{
    public static class RefitServiceProvider
    {
        public static T GetRemoteCalculationService<T>(IServiceProvider serviceProvider)
        {
            //Url разумеется берем из конфига
            return RestService.For<T>(new HttpClient() { BaseAddress = new Uri("http://localhost:49358") });
        }
    }
}
