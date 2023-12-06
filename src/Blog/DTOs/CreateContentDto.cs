using System.ComponentModel.DataAnnotations;

namespace Blog;
public class CreateContentDto
{
  
  public string  Name  { get; set; }
  
  public string  Title  { get; set; }
  
  public string  Content { get; set; }
  
  public string  Language  { get; set; }
}
