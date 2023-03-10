using System.ComponentModel.DataAnnotations;

namespace C1CopyMudBlazor.Data;

public class Account
{
    public int ID { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public ICollection<Role> Role { get; set; }

}
public class Role
{
    public int RoleID { get; set; }
    public string Name { get; set; }
    public ICollection<Account> Accounts { get; set; }
        
}