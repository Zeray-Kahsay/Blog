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

    public async Task<PagedList<Post>> GetAllPosts(PostParams postParams)
    {
        try
        {
            var query = _context.Posts
                      .Search(postParams.SearchTerm)
                      .Filter(postParams.Techs)
                      .AsQueryable();

            if (query == null) return null;
            var posts = await PagedList<Post>.ToPagedList(query, postParams.PageNumber, postParams.PageSize);

            return posts;

            //TODO: Get all comments to a post and their corresponding athour
            /*  
            posts = [
                {
                name:
                title:
                content:
                comments: [
                    {
                        body:
                        author:
                        authorPhot:
                        createdAt:
                    }
                ]
                likes: [
                    {
                        appUser:
                        post:

                    }
                ]
                
                }
            ]
            
            */
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
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<List<string>> GetFilters()
    {
        try
        {
        var techStack = await _context.Posts
                        .Select(post => post.Name)
                        .Distinct()
                        .ToListAsync();

            return techStack;
        }
        catch(Exception)
        {
            return null;
        }
    }
}
