using Microsoft.AspNetCore.Identity;

namespace Blog;
public class AppRole : IdentityRole<int> 
{
  public ICollection<AppUserRole> UserRoles { get; set; }
}
