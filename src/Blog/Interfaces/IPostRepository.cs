namespace Blog;
public interface IPostRepository
{
  Task<List<Post>> GetAllPosts();
  Task<Post> GetPostById(int id);
  Task<Post> CreatePost(CreateContentDto createContentDto);
  Task<Post> UpdatePost(UpdateContentDto updateContentDto);
  Task<bool> DeletePost(int id);

}
