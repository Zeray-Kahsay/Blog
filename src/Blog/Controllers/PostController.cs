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

        [HttpGet]
        public async Task<ActionResult<List<Post>>> GetPosts()
        {
           var posts = await  _postRepository.GetAllPosts();
            if (posts == null) return NotFound("Unable fetching posts");

            return posts; 
        }

        [HttpGet("{id}", Name = "GetPost")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            var post = await _postRepository.GetPostById(id);
            if (post == null) return NotFound("No Post found");

            return post; 
           
        }

        [HttpPost("createPost")]
        public async Task<ActionResult<Post>> CreatePost(CreateContentDto createContentDto)
        {
           var post = await  _postRepository.CreatePost(createContentDto);
            if (post == null) BadRequest("Problem creating a post");

            return CreatedAtRoute("GetPost", new { id = post.PostId }, post);
        }

        [HttpPut("updatePost")]
        public async Task<ActionResult<Post>> UpdatePost(UpdateContentDto updateContentDto)
        {
            var updatedContent =  await _postRepository.UpdatePost(updateContentDto);
            if (updatedContent == null) return NotFound("Post not found");
            return updatedContent; 
        }

        [HttpDelete("{id}", Name = "delete")]
        public async Task<ActionResult<bool>> DeletePost(int id)
        {
            var post = await _postRepository.DeletePost(id);
            if (!post) return NotFound("No post to delete with this Id");
            return Ok("successfully deleted!");
        }


    }
}