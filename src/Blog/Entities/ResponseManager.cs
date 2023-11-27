namespace Blog;
public class ResponseManager
{
  public int  UserId  { get; set; }
  public string  Username { get; set; }
  public string  Token  { get; set; }
  public string  Role  { get; set; }
  public string  Email  { get; set; }
  public string  Message  { get; set; }
  public bool  IsSuccess  { get; set; }
  public IEnumerable<string>  Errors { get; set; }
  

}
