using Microsoft.AspNet.Identity.EntityFramework;


namespace TechSpire.Domain.Entity;
public class AppUser : IdentityUser
{
    public string UserFullName { get; set; } = string.Empty;
}
