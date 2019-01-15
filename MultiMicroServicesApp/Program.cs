using System.Net;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace MultiMicroServicesApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DotNetEnv.Env.Load();
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel(options =>
                {
                    options.Listen(IPAddress.Any, 5000, configure =>
                    {
                        configure.UseConnectionLogging();

                    });
                    options.Listen(IPAddress.Any, 5001,
                        configure =>
                        {
                            configure.UseHttps(DotNetEnv.Env.GetString("pfxfilename"), DotNetEnv.Env.GetString("pfxpassword"));
                            configure.UseConnectionLogging();
                        });
                })
                .UseStartup<Startup>();
    }
}
