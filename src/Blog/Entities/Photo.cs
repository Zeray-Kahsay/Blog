namespace Blog;
public class Photo
{
  public int  Id  { get; set; }
  public string  PhotoUrl  { get; set; }
  public string  PublicId  { get; set; }
  public int  AppUserId  { get; set; }
  public AppUser AppUser  { get; set; }
}
