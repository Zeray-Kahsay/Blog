using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class PostController : BaseController 
    {
        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet("GetPosts")]
        public async Task<ActionResult<List<Post>>> GetPosts()
        {
           var posts = await  _postRepository.GetAllPosts();
            if (posts == null) return BadRequest("Unable fetching posts");

            return posts; 
        }

        [HttpGet("{id}", Name = "GetPost")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            var post = await _postRepository.GetPostById(id);
            if (post == null) return NotFound();

            return post; 
           
        }

        [HttpPost("createPost")]
        public async Task<ActionResult<Post>> CreatePost(CreateContentDto createContentDto)
        {
           var post = await  _postRepository.CreatePost(createContentDto);
            if (post == null) BadRequest("Problem creating a post");

            return CreatedAtRoute("GetPost", new { id = post.PostId }, post);
        }


    }
}