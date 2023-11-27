namespace Blog;
public interface IContentRepository
{
  Task<ContentDto> GetAllContents();
  Task<ContentDto> GetContentById(int id);
  Task<ContentDto> CreateContent(CreateContentDto createContentDto);
  Task<ContentDto> UpdateContent(UpdateContentDto updateContentDto);
  Task<bool> DeleteContent(int id);

}
