using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CSVApp.DAL;
using CSVApp.DAL.Utils;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CSVApp {
    public class Program {
        public static void Main(string[] args) {
            CreateWebHostBuilder(args)
                .Build()
                .SeedData()
                .Run();
        }

        private static IWebHostBuilder CreateWebHostBuilder(string[] args) {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddCommandLine(args)
                .Build();

            var port = config.GetValue<string>("Port");

            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls(urls: "http://localhost:" + port);
        }
    }

	public static class StartupHelpers {
		public static IWebHost SeedData(this IWebHost host) {
			using (var scope = host.Services.CreateScope()) {
                var services = scope.ServiceProvider;
                var dbContext = services.GetService<ApplicationDbContext>();
                DataSeeder.SeedCountryValues(dbContext);
                DataSeeder.SeedItemTypeValues(dbContext);
                DataSeeder.SeedRegionValues(dbContext);
                DataSeeder.SeedSalesChannelValues(dbContext);
            }
            return host;
		}
	}
}
