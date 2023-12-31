﻿namespace Blog;
public interface IPostRepository
{
  Task<PagedList<Post>> GetAllPosts(PostParams postParams);
  Task<Post> GetPostById(int id);
  Task<Post> CreatePost(CreateContentDto createContentDto);
  Task<Post> UpdatePost(UpdateContentDto updateContentDto);
  Task<bool> DeletePost(int id);
  Task<List<string>> GetFilters(); 

}
