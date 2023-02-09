using System.ComponentModel.DataAnnotations;

namespace C1CopyMudBlazor.Data;

public class Account
{
    public int ID { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int RoleID { get; set; }
    public Role Role { get; set; }

}
public class Role
{
    public int RoleID { get; set; }
    public string Name { get; set; }
    public List<Account> Accounts { get; set; }
        
}
public class User
{
    public int Id { get; set; }
    [Required(ErrorMessage ="Слишком больше имя")]
    public string Name { get; set; } = ""; // имя пользователя
    public int Age { get; set; }
    public string PhoneNumber { get; set; }
}