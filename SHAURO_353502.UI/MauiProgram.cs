using CommunityToolkit.Maui;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SHAURO_353502.Application;
using SHAURO_353502.Persistense;
using SHAURO_353502.Persistense.Data;
using System.Reflection;

namespace SHAURO_353502.UI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            string settingsStream = "SHAURO_353502.UI.appsettings.json";

            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            var a = Assembly.GetExecutingAssembly();
            using var stream = a.GetManifestResourceStream(settingsStream);
            builder.Configuration.AddJsonStream(stream);

            var connStr = builder.Configuration.GetConnectionString("SqliteConnection");
            string dataDirectory = "D:\\BSUIR\\Project\\OOP\\SHAURO_353502" + "\\";
            connStr = String.Format(connStr, dataDirectory);

            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite(connStr)
                .Options;

#if DEBUG
            builder.Logging.AddDebug();
            builder.Services
                    .AddApplication()
                    .AddPersistence(options)
                    .RegisterViewModels()
                    .RegisterPages();

#endif

            DbInitializer
                .Initialize(builder.Services.BuildServiceProvider())
                .Wait();


            return builder.Build();
        }
    }
}
