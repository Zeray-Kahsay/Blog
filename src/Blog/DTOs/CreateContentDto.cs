using System.ComponentModel.DataAnnotations;

namespace Blog;
public class CreateContentDto
{
  [Required]
  public string  Name  { get; set; }
  [Required]
  public string  Title  { get; set; }
  [Required]
  public string  Content { get; set; }
}
