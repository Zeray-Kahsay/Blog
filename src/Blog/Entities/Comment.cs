namespace Blog;
public class Comment
{
  public int  Id  { get; set; }
  public string  Body { get; set; }
  public AppUser Author { get; set; }
  public int  UserId { get; set; }
  public Post Post  { get; set; }
  public int  PostId { get; set; }
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

}
