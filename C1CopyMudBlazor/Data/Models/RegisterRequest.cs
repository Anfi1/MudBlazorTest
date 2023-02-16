using System.ComponentModel.DataAnnotations;

namespace C1CopyMudBlazor.Data.Models;

public class RegisterRequest
{
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    [Compare(nameof(Password), ErrorMessage = "Пароли не сходятся")]
    public string PasswordConfirm { get; set; }
}