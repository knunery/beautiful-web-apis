using System;
using Microsoft.AspNetCore.Hosting;

namespace aspnetcoreapp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel(options => { options.AddServerHeader = false; })
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
