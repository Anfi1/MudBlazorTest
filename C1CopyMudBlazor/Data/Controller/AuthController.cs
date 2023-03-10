using System.Diagnostics;
using System.Net;
using System.Security.Claims;
using C1CopyMudBlazor.Data;
using C1CopyMudBlazor.Pages.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AuthenticationManager = Microsoft.AspNetCore.Server.HttpSys.AuthenticationManager;

namespace C1CopyMudBlazor.Pages.Controller;

[Route("login")]
public class AuthController : ControllerBase
{
    private HttpContext context;
    private ApplicationContext db;
    private readonly ILogger _logger;
    
    public AuthController(IHttpContextAccessor httpContext, ApplicationContext db, ILogger<AuthController> logger)
    {
        context = httpContext.HttpContext;
        this.db = db;
        _logger = logger;
    }

    [HttpPost]
    public IActionResult LoginAccount()
    {
        var form = context.Request.Form;
        // если email и/или пароль не установлены, посылаем статусный код ошибки 400
        if (!form.ContainsKey("email") || !form.ContainsKey("password"))
            return (IActionResult)Results.BadRequest("Email и/или пароль не установлены");
 
        string email = form["email"];
        string password = form["password"];
        List<Account> people;
        people = db.Account.Include(x=>x.Role).ToList();

        // находим пользователя 
        Account? person = people.FirstOrDefault(p => p.Email == email && p.Password == password);
        // если пользователь не найден, отправляем статусный код 401
        if (person is null) return (IActionResult)Results.Unauthorized();
 
        var claims = new List<Claim> 
        {   new Claim(ClaimsIdentity.DefaultNameClaimType, person.Email), };
        foreach (var role in person.Role)
        {
            claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, role.Name));
            _logger.LogInformation($"{role.Name} added");
        }
        // создаем объект ClaimsIdentity
        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        // установка аутентификационных куки
        var a =context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
        if (a.IsCompleted)
        {
            return Redirect("/");
        }
        return Redirect("/Error");
    }

}