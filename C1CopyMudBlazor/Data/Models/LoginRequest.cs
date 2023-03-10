using System.ComponentModel.DataAnnotations;

namespace C1CopyMudBlazor.Data.Models;

public class LoginRequest
{
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }
    public bool RememberMe { get; set; }
}