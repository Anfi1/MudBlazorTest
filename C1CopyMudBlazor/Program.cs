using System.Security.Claims;
using C1CopyMudBlazor.Data;
using C1CopyMudBlazor.Data.Interfaces;
using C1CopyMudBlazor.Data.Services;
using C1CopyMudBlazor.Pages.Auth;
using C1CopyMudBlazor.Pages.Controller;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContext<ApplicationContext>(o => o.UseSqlServer(connectionString));
//new MySqlServerVersion(new Version(8, 0, 29)))
builder.Services.AddOptions();
builder.Services.AddSingleton<FileService>();
builder.Services.AddMudServices();
builder.Services.AddScoped<Account>();
builder.Services.AddScoped<Role>();
builder.Services.AddScoped<IOfficeService, OfficeService>();
builder.Services.AddScoped<IWorkerService, WorkerService>();
builder.Services.AddScoped<ILegalEntitiesService, LegalEntitiesService>();
builder.Services.AddScoped<IWorkPlaceService, WorkPlaceService>();
builder.Services.AddScoped<ITechService, TechService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ClipboardService>();
builder.Services.AddScoped<CookieAuthenticationEventsService>();
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews();

// аутентификация с помощью куки
builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    })
    .AddCookie(options =>
    {
        options.SlidingExpiration = true;
        options.LoginPath = "/login";
        options.ExpireTimeSpan = TimeSpan.FromDays(7);
        options.Cookie.MaxAge = options.ExpireTimeSpan;
        options.AccessDeniedPath = "/Forbidden";
        options.EventsType = typeof(CookieAuthenticationEventsService);
    });
builder.Services.AddAuthorization();
builder.Services.Configure<SecurityStampValidatorOptions>(options =>
{
    // This is the key to control how often validation takes place
    options.ValidationInterval = TimeSpan.Zero;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints=>
{
    // This is the line you need to add
    endpoints.MapControllers();

    endpoints.MapBlazorHub();
    endpoints.MapFallbackToPage("/_Host");
});

app.MapGet("/login", async (HttpContext context) =>
{
    context.Response.ContentType = "text/html; charset=utf-8";
    // html-форма для ввода логина/пароля
    string loginForm = @"<!DOCTYPE html>
    <html>
    <head>
        <meta charset='utf-8' />
        <title>TMPLogin</title>
    </head>
    <body>
        <h2>Login Form</h2>
        <form method='post'>
            <p>
                <label>Email</label><br />
                <input name='email' />
            </p>
            <p>
                <label>Password</label><br />
                <input type='password' name='password' />
            </p>
            <input type='submit' value='Login' />
        </form>
    </body>
    </html>";
    await context.Response.WriteAsync(loginForm);
});

app.MapGet("/logout", async (HttpContext context) =>
{
    await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    return Results.Redirect("/");
});

app.Run();