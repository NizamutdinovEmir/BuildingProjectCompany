using BuildCompany.Domain;
using BuildCompany.Domain.Repositories.Abstract;
using BuildCompany.Domain.Repositories.EntityFramework;
using BuildCompany.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Serilog;

namespace BuildCompany;

public class Program
{
#pragma warning disable CA1506
    public static async Task Main(string[] args)
#pragma warning restore CA1506
    {
        // нужно порефакторить код, слишком много взаимозависимости
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        // Подключаем в конфигурацию файл appsettings.json
        IConfigurationBuilder configBuild = new ConfigurationBuilder()
            .SetBasePath(builder.Environment.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();

        // Оборачиваем секцию Project в объектную форму для удобства
        IConfiguration configuration = configBuild.Build();
        AppConfig config = configuration.GetSection("Project").Get<AppConfig>()!;

        // Подключаемся к бд
        builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(config.DataBase.ConnectionString)
            .ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning)));

        builder.Services.AddTransient<IServiceCategoriesRepository, EFServiceCategoriesRepository>();
        builder.Services.AddTransient<IServicesRepository, EFServicesRepository>();
        builder.Services.AddTransient<DataManager>();

        // Настраиваем Identity систему
        builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
            })
           .AddEntityFrameworkStores<AppDbContext>();

        // Auth Cookie
        builder.Services.ConfigureApplicationCookie(options =>
        {
            options.Cookie.Name = "BuildCompanyAuth";
            options.Cookie.HttpOnly = true;
            options.LoginPath = "/account/login";
            options.LogoutPath = "/admin/accessdenied/";
            options.SlidingExpiration = true;
        });

        // Поключаем контроллеры
        builder.Services.AddControllersWithViews();

        // Настраиваем Serilog
        builder.Host.UseSerilog((context, configuration) =>
            configuration.ReadFrom.Configuration(context.Configuration));

        // Собираем конфигурацию
        WebApplication app = builder.Build();

        app.UseSerilogRequestLogging();

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        // Статичные файлы (js, css..)
        app.UseStaticFiles();

        // Система маршрутизации
        app.UseRouting();

        // Подключаем аутентификацию
        app.UseCookiePolicy();
        app.UseAuthentication();
        app.UseAuthorization();

        // Регистрируем маршруты
        app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

        await app.RunAsync();
    }
}
