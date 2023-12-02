using Microsoft.AspNetCore.Identity;

namespace Blog;
public static class DbItinializer
{

  public static async Task Initialize(BlogContext context, UserManager<AppUser> userManager)
  {

    if (!userManager.Users.Any())
    {
      var user = new AppUser
      { 
        UserName = "zerkah4@gmail.com",
        Email = "zerkah4@gmail.com"
      };

      await userManager.CreateAsync(user, "Pa$$w0rd");
      await userManager.AddToRoleAsync(user, "Member");


      var admin = new AppUser
      { 
        UserName = "admin",
        Email = "Kahsayzeray@gmail.com"
      };

      await userManager.CreateAsync(admin, "Pa$$w0rd");
      await userManager.AddToRolesAsync(admin, new[] { "Member", "Admin" });
    }

    if (context.Posts.Any()) return;

    var posts = new List<Post>
    {
      new Post 
      {
        Name = "Netcore",
        Title = "Authorization and Authentication with JWT",
        Content = "In this article, we will work on implementing C# JWT Authentication using .NET 7 - which also works for .NET 6, and preview .NET 8 - using ASP.NET Core.",
        Language = "DotNet Core"    
      },
      new Post 
      {
        Name = "React",
        Title = "React Query",
        Content = " TanStack Query (FKA React Query) is often described as the missing data-fetching library for web applications, but in more technical terms, it makes fetching, caching, synchronizing and updating server state in your web applications a breeze.",
        Language = "React"
      },
      new Post
      {
        Name = "Javascript",
        Title = "Arrays",
        Content = " Array elements are object properties in the same way that toString is a property (to be specific, however, toString() is a method). Nevertheless, trying to access an element of an array as follows throws a syntax error because the property name is not valid",
        Language = "Javascript"
      },
       new Post
       {
        Name = "Netcore2",
        Title = "Authorization and Authentication with JWT",
        Content = "In this article, we will work on implementing C# JWT Authentication using .NET 7 - which also works for .NET 6, and preview .NET 8 - using ASP.NET Core.",
        Language = "DotNet Core"    
      },
      new Post 
      {
        Name = "React2",
        Title = "React Query",
        Content = " TanStack Query (FKA React Query) is often described as the missing data-fetching library for web applications, but in more technical terms, it makes fetching, caching, synchronizing and updating server state in your web applications a breeze.",
        Language = "React"
      },
      new Post
      {
        Name = "Javascript2",
        Title = "Arrays",
        Content = " Array elements are object properties in the same way that toString is a property (to be specific, however, toString() is a method). Nevertheless, trying to access an element of an array as follows throws a syntax error because the property name is not valid",
        Language = "Javascript"
      }
    };

    foreach (var post in posts)
    {
      context.Posts.Add(post);
    }

    await context.SaveChangesAsync();
  }

}
