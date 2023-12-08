namespace Blog;

public class PostParams : PaginationParams
{
    public string  SearchTerm  { get; set; }
    public string  Techs { get; set; }
}
