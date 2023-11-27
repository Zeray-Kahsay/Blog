using Microsoft.AspNetCore.Components.Web;

namespace Blog;
public class Post
{
  public int PostId  { get; set; }
  public string  Name  { get; set; }
  public string  Content  { get; set; }
  public string  Title { get; set; }
  public string  Language  { get; set; }
  public ICollection<Comment> Comments { get; set; } = new List<Comment>();
  public ICollection<Likes> Likes { get; set; } = new List<Likes>();
  public DateTime PublishedAt { get; set; } = DateTime.UtcNow;


}
