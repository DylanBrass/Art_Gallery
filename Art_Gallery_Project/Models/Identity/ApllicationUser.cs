using Microsoft.AspNetCore.Identity;

namespace Art_Gallery_Project.Models.Identity;

public class ApllicationUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}