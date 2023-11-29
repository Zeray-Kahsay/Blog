using AutoMapper;

namespace Blog;
public class AutoMapperProfiles : Profile
{
  public AutoMapperProfiles()
  {
    CreateMap<CreateContentDto, Post>();
    CreateMap<UpdateContentDto, Post>();
  }
}
