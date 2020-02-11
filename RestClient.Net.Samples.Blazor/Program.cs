#if (NETCOREAPP3_1)
using Microsoft.AspNetCore.Hosting;
#else
using System.Threading.Tasks;
#endif

using Microsoft.Extensions.Hosting;

namespace BlazorApp1
{
    public class Program
    {
        //This is for server side rendering
#if (NETCOREAPP3_1)
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
#else
        //Client side Blazor rendering
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            await builder.Build().RunAsync();
        }
#endif
    }
}
