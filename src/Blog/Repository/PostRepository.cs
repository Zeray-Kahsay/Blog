
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

    public async Task<Post> UpdatePost( [FromBody] UpdateContentDto updateContentDto)
    {
        try
        {
            var post = await _context.Posts.FirstOrDefaultAsync(p => p.PostId == updateContentDto.Id);
            if (post == null) return null;
            _mapper.Map(updateContentDto, post);
           // var updatedPost =  _mapper.Map<UpdateContentDto>(post);
             await _context.SaveChangesAsync();
            return post;
            
        }
        catch (Exception)
        {
            return null;
        }

    }
    public async Task<bool> DeletePost(int id)
    {
        try 
        {
            var post = await _context.Posts.FindAsync(id);
            //if (post == null) return false;
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
