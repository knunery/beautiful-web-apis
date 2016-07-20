using System;
using Microsoft.AspNetCore.Hosting;

namespace aspnetcoreapp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // protip: remove Kestrel server header
            var host = new WebHostBuilder()
                .UseKestrel(options => { options.AddServerHeader = false; })
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
