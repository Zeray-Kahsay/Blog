namespace Blog;
public interface ITokenService
{
  Task<string> GenerateToken(AppUser user);
}
