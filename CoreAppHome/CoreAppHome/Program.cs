using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using CoreAppHome.Extensions;
using CoreAppHome.Models;
using CoreAppHome.Data;

namespace CoreAppHome
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // CreateWebHostBuilder(args).Build().Run();
            CreateWebHostBuilder(args).Build()
                                 .MigrateDatabase<ApplicationDbContext>()
                                 .MigrateDatabase<AppHomeDbContext>()
                                 .Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
