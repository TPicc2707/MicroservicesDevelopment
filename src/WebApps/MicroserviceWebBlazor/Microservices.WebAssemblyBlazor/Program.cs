using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microservices.WebAssemblyBlazor.Services;
using Microservices.WebAssemblyBlazor.Extensions;

namespace Microservices.WebAssemblyBlazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddSingleton<Navigation>();

            builder.Services.AddSingleton<PageHistoryState>();
            builder.Services.AddHttpClient<IPersonService, PersonService>(client =>
            {
                client.BaseAddress = new Uri("http://localhost:8000");
            });
            builder.Services.AddHttpClient<IAddressService, AddressService>(client =>
            {
                client.BaseAddress = new Uri("http://localhost:8001");
            });
            builder.Services.AddHttpClient<IPersonAddressService, PersonAddressService>(client =>
            {
                client.BaseAddress = new Uri("http://localhost:8000");
            });

            await builder.Build().RunAsync();
        }
    }
}
