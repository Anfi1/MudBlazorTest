using System.Security.Claims;
using C1CopyMudBlazor.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using MudBlazor;

namespace C1CopyMudBlazor.Pages.Controller;

public class CookieAuthenticationEventsService  : CookieAuthenticationEvents
{
    private readonly ApplicationContext db;

    public CookieAuthenticationEventsService(ApplicationContext db)
    {
        // Get the database from registered DI services.
        this.db = db;
    }

    public override async Task ValidatePrincipal(CookieValidatePrincipalContext context)
    { 
        var userPrincipal = context.Principal;

        // Look for the LastChanged claim.
        var Lastclaims = userPrincipal.Claims.Where(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).ToList();
        var account = db.Account.Include(x => x.Role).FirstOrDefault(x => x.Email == userPrincipal.Identity.Name);

        if (true)
        {
            var claims = new List<Claim> 
            {   new Claim(ClaimsIdentity.DefaultNameClaimType, account.Email)
            };
            foreach (var role in account.Role)
            {
                claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, role.Name));
                
            }
            // создаем объект ClaimsIdentity
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var newuserPrincipal = new ClaimsPrincipal(claimsIdentity) ;
            context.ShouldRenew = true;
            context.ReplacePrincipal(newuserPrincipal);
        }
        
    }
}