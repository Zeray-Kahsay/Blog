namespace Blog;
public class Likes
{
  public AppUser AppUser { get; set; }
  public int  AppUserId { get; set; }
  public Post Post { get; set; }
  public int  PostId { get; set; }

}
