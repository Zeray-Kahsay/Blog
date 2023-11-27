using Microsoft.AspNetCore.Identity;

namespace Blog;
public class AppUser : IdentityUser<int>
{
  public DateTime CreatedAt { get; set; } =  DateTime.UtcNow;
  public List<Comment> UserComments { get; set; }
  public List<Likes> UserLikes { get; set; }
  public ICollection<AppUserRole> UserRoles { get; set; }
  
}
