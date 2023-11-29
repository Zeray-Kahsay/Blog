
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Blog;
public class PostRepository : IPostRepository
{
  private readonly BlogContext _context;
    private readonly IMapper _mapper;
  public PostRepository(BlogContext context, IMapper mapper)
  {
      _mapper = mapper;
      _context = context; 
  }
    public async Task<Post> CreatePost(CreateContentDto createContentDto)
    {
        try
        {
          var post = _mapper.Map<Post>(createContentDto);
           _context.Posts.Add(post);
           var result =  await _context.SaveChangesAsync() > 0;

            if (result) return post;

            return null;
        }
        catch(Exception)
        {
            return null;
        }

    }

    public async Task<List<Post>> GetAllPosts()
    {
        try
        {
            var posts = await _context.Posts.ToListAsync();
             if (posts == null) return null;
            return posts;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<Post> GetPostById(int id)
    {
        try 
        {
            return  await _context.Posts.FindAsync(id);
        }
        catch (Exception)
        {
            return null;
        }
    }

    public Task<ContentDto> UpdatePost(UpdateContentDto updateContentDto)
    {
        throw new NotImplementedException();
    }
    public Task<bool> DeletePost(int id)
    {
        throw new NotImplementedException();
    }
}
