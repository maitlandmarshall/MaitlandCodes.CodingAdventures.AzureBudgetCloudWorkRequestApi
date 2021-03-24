using MaitlandCodes.CodingAdventures.BudgetCloudWorkRequestApi;
using MaitlandCodes.CodingAdventures.BudgetCloudWorkRequestApi.Data;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

[assembly: FunctionsStartup(typeof(Startup))]
namespace MaitlandCodes.CodingAdventures.BudgetCloudWorkRequestApi
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var services = builder.Services;
            var home = Environment.GetEnvironmentVariable("HOME") ?? "";
            var databasePath = Path.Combine(home, "database.sqlite");

            services.AddScoped<WorkRequestDbContext>(svc =>
            {
                var options = new DbContextOptionsBuilder<WorkRequestDbContext>().UseSqlite($"Data Source={databasePath};");
                return new WorkRequestDbContext(options.Options);
            });
        }

        public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        {
            base.ConfigureAppConfiguration(builder);
        }
    }
}
