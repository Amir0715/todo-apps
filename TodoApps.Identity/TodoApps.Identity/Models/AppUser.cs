using Microsoft.AspNetCore.Identity;

namespace TodoApps.Identity.Models;

public class AppUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}