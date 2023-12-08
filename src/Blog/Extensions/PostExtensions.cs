namespace Blog;

public static class PostExtensions
{

   
    public static IQueryable<Post> Search (this IQueryable<Post> query, string searchTerm)
    {
        if (string.IsNullOrEmpty(searchTerm)) return query;

        var lowerCaseSearchTerm = searchTerm.Trim().ToLower();

        return query.Where(p => p.Name.ToLower().Contains(lowerCaseSearchTerm));
    }

    public static IQueryable<Post> Filter(this IQueryable<Post> query, string techs)
    {
        var techList = new List<string>();

        if (!string.IsNullOrEmpty(techs))
        {
            techList.AddRange(techs.ToLower().Split(",").ToList());
        }

        query = query.Where(post => techList.Count == 0 || techList.Contains(post.Name.ToLower()));

        return query;
    }

}
